using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovePlatform : MonoBehaviour
{
    public Vector2 moveSpeed;
    public Vector2 start;
    public Vector2 end;

    private Rigidbody2D body;
    private int moveDirectionX;
    private int moveDirectionY;

    private bool isInRange = true;
    private bool isFlipDirectionAllowed = true;
    
    private float PosY()
    {
        return transform.position.y;
    }

    private float PosX()
    {
        return transform.position.x;
    }

    private void Awake()
    {
        InitBody();
        InitMoveDirection();
    }

    private void InitBody()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void InitMoveDirection()
    {
        moveDirectionY = Random.Range(0, 2) == 0 ? -1 : 1;
        moveDirectionX = Random.Range(0, 2) == 0 ? -1 : 1;
    }

    private void FixedUpdate()
    {
        UpdateIsInRange();
        UpdateDirection();
        UpdateVelocity();
    }
    
    
    private bool ShouldFlipRandom()
    {
        return isInRange && Random.Range(0, 120) == 0;
    }
    
    private void UpdateIsInRange()
    {
        isInRange = PosY() < end.y && PosY() > start.y && PosX() < end.x && PosX() > start.x;
        if (isInRange)
        {
            isFlipDirectionAllowed = true;
        }
    }

    private void UpdateDirection()
    {
        if (isFlipDirectionAllowed && (!isInRange /* || ShouldFlipRandom() */ ))
        {
            FlipDirection();
        }
    }

    private void FlipDirection()
    {
        moveDirectionX = moveDirectionX > 0 ? -1 : 1;
        moveDirectionY = moveDirectionY > 0 ? -1 : 1;
        isFlipDirectionAllowed = false;
    }

    private void UpdateVelocity()
    {
        body.velocity = new Vector2(moveDirectionX * moveSpeed.x, moveDirectionY * moveSpeed.y);
    }
}
