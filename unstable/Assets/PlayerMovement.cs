using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private float movingDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

//    void Start()
//    {
//    }


    void Update()
    {
        movingDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movingDirection * moveSpeed, rb.velocity.y);
    }
}
