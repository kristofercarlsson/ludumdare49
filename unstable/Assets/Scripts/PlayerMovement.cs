using System;
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

    private Vector2 platformVelocity = new Vector2(0f, 0f);
    private int platformCollisionCount = 0;
    
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Platform")
        {
            platformCollisionCount++;
        }
        UpdatePlatformVelocity(other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Platform")
        {
            platformCollisionCount--;
        }

        UpdatePlatformVelocity(other);
    }

    private void UpdatePlatformVelocity(Collision2D other)
    {
        platformVelocity.x = platformCollisionCount > 0 ? other.rigidbody.velocity.x : 0f;
        platformVelocity.y = platformCollisionCount > 0 ? other.rigidbody.velocity.y : 0f;
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(platformVelocity.x + movingDirection * moveSpeed, platformVelocity.y + rb.velocity.y);
        if (isJumping)
        {
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
