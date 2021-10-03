using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float moveSpeed;
    public float maxY;
    public float minY;

    private Rigidbody2D body;
    private int moveDirection;

    private float PosY()
    {
        return transform.position.y;
    }

    private void FlipDirection()
    {
        moveDirection = moveDirection > 0 ? -1 : 1;
    }

    private bool ShouldFlipDirection()
    {
        var isInRange = PosY() < maxY && PosY() > minY;
        if (isInRange)
        {
            return Random.Range(0, 120) == 0;
        }
        if (moveDirection == 1)
        {
            return PosY() > maxY;
        }
        return PosY() < minY;
    }

    private void UpdateVelocity()
    {
        if (ShouldFlipDirection())
        {
            FlipDirection();
        }
        body.velocity = new Vector2(body.velocity.y, moveDirection * moveSpeed);
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
        var random = Random.Range(0, 2);
        if (random == 0)
        {
            moveDirection = -1;
        }
        else
        {
            moveDirection = 1;
        }
    }

    private void FixedUpdate()
    {
        UpdateVelocity();
    }
}
