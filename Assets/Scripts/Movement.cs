using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    public Transform lowPoint;

    private float horizontal;
    private Rigidbody2D rb;
    private new SpriteRenderer renderer;
    private Animator animator;

    private bool jump = false;

    private static readonly int EnvironmentLayer = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        var left = false;
        var right = false;
#if UNITY_ANDROID
        for (int i = 0; i < Input.touchCount; i++)
        {
            var touch = Input.GetTouch(i);
            var pos = touch.position;
            if (pos.x > Screen.width / 2)
            {
                right = true;
            }
            else
            {
                left = true;
            }
        }

#endif
#if UNITY_EDITOR
        left |= Input.GetKey(KeyCode.A);
        right |= Input.GetKey(KeyCode.D);
#endif

        if (left && !right) horizontal = -2f;
        else
        {
            if (!left && right) horizontal = 2f;
            else
            {
                horizontal *= 0.7f;
                if (left && right && !OnTheGround())
                {
                    jump = true;
                }
            }
        }

        if (horizontal > 0)
        {
            renderer.flipX = true;
        }
        if (horizontal < 0)
        {
            renderer.flipX = false;
        }
        if (horizontal == 0)
        {
            animator.SetBool("moving", false);
        }
        else
        {
            animator.SetBool("moving", true);
        }
    }

    private bool OnTheGround()
    {
        var min = lowPoint.position;
        Debug.DrawLine(min, transform.position, Color.green);

        var rightPoint = min + Vector3.right * 0.1f;
        var leftPoint = min + Vector3.left * 0.1f;
        Debug.DrawLine(leftPoint, rightPoint, Color.green);

        var hit = Physics2D.Raycast(rightPoint, Vector2.left, 0.2f);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return false;
        }

        return true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (jump)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        // Get the velocity
        Vector2 horizontalMove = (rb.velocity + new Vector2(horizontal * speed, rb.velocity.y)) / 2;

        rb.velocity = horizontalMove;
    }
}
