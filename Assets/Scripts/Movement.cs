﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 5f;

    private float horizontal;
    private Rigidbody2D rb;
    private new SpriteRenderer renderer;
    private Animator animator;
    private new CircleCollider2D collider;

    private static readonly int EnvironmentLayer = 8;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
    }
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
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
        if (!OnTheGround() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    private bool OnTheGround()
    {
        var min = transform.position + Vector3.down * (collider.radius + 0.1f) * transform.localScale.x;
        Debug.DrawLine(min, transform.position, Color.green);

        var rightPoint = min + Vector3.right * collider.radius;
        var leftPoint = min + Vector3.left * collider.radius;
        Debug.DrawLine(leftPoint, rightPoint, Color.green);

        var hit = Physics2D.Raycast(rightPoint, Vector2.left, collider.radius * 1.6f * transform.localScale.x);
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
        // Get the velocity
        Vector2 horizontalMove = (rb.velocity + new Vector2(horizontal * speed, rb.velocity.y)) / 2;

        rb.velocity = horizontalMove;

        FinalCollisionCheck();
    }

    private void FinalCollisionCheck()
    {
        // Get the velocity
        Vector2 moveDirection = rb.velocity * Time.fixedDeltaTime * 2.1f;
        Vector2 position = transform.position;
        var distance = Time.fixedDeltaTime * 10f + collider.radius * transform.localScale.x;
        // Check if the body's current velocity will result in a collision
        var hits = Physics2D.RaycastAll(position, moveDirection.normalized, distance);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer.Equals(EnvironmentLayer))
            {
                Debug.DrawLine(hit.transform.position, transform.position, Color.red);
                // If so, stop the movement
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }

        hits = Physics2D.RaycastAll(position, (moveDirection.normalized + Vector2.up) * 0.5f, distance);
        foreach (var hit in hits)
        {
            if (hit.collider.gameObject.layer.Equals(EnvironmentLayer))
            {
                Debug.DrawLine(hit.transform.position, transform.position, Color.red);
                // If so, stop the movement
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
        }
    }
}
