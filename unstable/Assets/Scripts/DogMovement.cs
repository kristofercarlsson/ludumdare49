using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D enemyRigidBody2D;

    public int unitsToMove = 5;
    public float enemySpeed = 500;

    public bool isFacingRight;
    public bool moveRight = true;

    private float startPos;
    private float endPos;

    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        startPos = transform.position.x;
        endPos = (startPos - unitsToMove) + unitsToMove;
        isFacingRight = transform.localScale.x > 0;
    }

    public void Update()
    {
        // target player
        startPos = player.transform.position.x;
        endPos = player.transform.position.x + unitsToMove;

        if (moveRight)
        {
            enemyRigidBody2D.AddForce(Vector2.right * enemySpeed * Time.deltaTime);
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (enemyRigidBody2D.position.x >= endPos)
        {
            moveRight = false;
        }

        if (!moveRight)
        {
            enemyRigidBody2D.AddForce(-Vector2.right * enemySpeed * Time.deltaTime);
            if (isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x <= startPos)
        {
            moveRight = true;
        }
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        isFacingRight = transform.localScale.x > 0;
    }
}