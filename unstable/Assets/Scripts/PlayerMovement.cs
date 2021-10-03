using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float checkRadius;

    public Transform ceilingCheck;
    public Transform groundCheck;

    public LayerMask groundObjects;

    private bool isGrounded;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float movingDirection;
    private bool isJumping = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();

        Animate();
    }

    private void ProcessInputs()
    {
        movingDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(movingDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            Debug.Log("Add force: " + jumpForce);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        isJumping = false;
    }

    private void Animate()
    {
        if (movingDirection > 0 && !facingRight)
        {
            FlipPlayer();
        }
        else if (movingDirection < 0 && facingRight)
        {
            FlipPlayer();
        }
    }

    private void FlipPlayer()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
