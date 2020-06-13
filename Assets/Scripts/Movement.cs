using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;
    public Transform lowPoint;

    private float horizontal;
    private Rigidbody2D rb;
    private new SpriteRenderer renderer;
    private Animator animator;

    public TextMeshProUGUI text;

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
        if (IsPointerOverUIObject()) return;
        var horizontalPrev = 0f;
        var jumpPrev = false;
#if UNITY_ANDROID
        if (GameState.RotationMovement)
        {
            if (Input.touchCount > 0)
            {
                jumpPrev = true;
            }
            Vector3 tilt = Input.acceleration;
            horizontalPrev = tilt.x * 4f;
        }
        else
        {
            var left = false;
            var right = false;
            for (int i = 0; i < Input.touchCount; i++)
            {
                var touch = Input.GetTouch(i);

                var pos = touch.position;
                if (pos.x > Screen.width / 2)
                {
                    right = true;
                    horizontalPrev += 2;
                }
                else
                {
                    left = true;
                    horizontalPrev += -2;
                }
            }
            jumpPrev = left && right;
        }


#endif
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.A))
        {
            horizontalPrev += -2;
            if (Input.GetKey(KeyCode.D))
            {
                jumpPrev = true;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalPrev += 2;
        }

#endif
        horizontal = horizontalPrev;
        if (jumpPrev && !OnTheGround())
        {
            jump = true;
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

    private bool IsPointerOverUIObject()
    {
        return (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null);
    }
}
