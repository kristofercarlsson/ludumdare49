using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatMovement : MonoBehaviour
{
    public Rigidbody2D targetBody;
    public float moveForce = 500;
    public float viewDistance = 10f;

    private Rigidbody2D body;
    private Vector2 position;
    private Vector2 targetPosition;

    private int directionX = 1;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        position.x = transform.position.x;
        position.y = transform.position.y;

        targetPosition.x = targetBody.transform.position.x;
        targetPosition.y = targetBody.transform.position.y;

        if (Vector2.Distance(position, targetPosition) < viewDistance)
        {
            var newDirectionX = position.x < targetPosition.x ? 1 : -1;
            if (newDirectionX != directionX)
            {
                transform.transform.Rotate(0f, 180f, 0f);
            }
            directionX = newDirectionX;
            
            var force = (targetPosition - position).normalized;
            
            force.x = (force.x * moveForce * Time.deltaTime);
            force.y = (force.y * moveForce * Time.deltaTime);

            body.AddForce(force);
        }
    }
}