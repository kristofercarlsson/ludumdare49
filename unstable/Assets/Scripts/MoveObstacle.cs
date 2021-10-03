using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public float startVelocity;

    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2( startVelocity, body.velocity.y);
    }
}