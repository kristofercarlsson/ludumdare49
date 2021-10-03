using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Rigidbody2D body;

    public int unitsToMove = 5;
    public float enemySpeed = 500;

    private bool isFacingRight;
    private bool moveRight = true;

    private float playerStartPos;
    private float playerEndPos;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerStartPos = transform.position.x;
        playerEndPos = playerStartPos;
        isFacingRight = transform.localScale.x > 0;
    }

    public void Update()
    {
        // target player
        playerStartPos = playerBody.transform.position.x;
        playerEndPos = playerBody.transform.position.x + unitsToMove;

        if (moveRight)
        {
            body.AddForce(Vector2.right * enemySpeed * Time.deltaTime);
            if (!isFacingRight)
            {
                Flip();
            }
        }

        if (body.position.x >= playerEndPos)
        {
            moveRight = false;
        }

        if (!moveRight)
        {
            body.AddForce(-Vector2.right * enemySpeed * Time.deltaTime);
            if (isFacingRight)
                Flip();
        }

        if (body.position.x <= playerStartPos)
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