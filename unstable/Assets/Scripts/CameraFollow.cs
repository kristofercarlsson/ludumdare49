using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector2 followDistance;

    private void Update()
    {
        var diffX = target.position.x - transform.position.x;
        var diffY = target.position.y - transform.position.y;

        var newPositionX = Math.Abs(diffX) > followDistance.x
            ? target.position.x - Math.Sign(diffX) * followDistance.x
            : transform.position.x;

        var newPositionY = Math.Abs(diffY) > followDistance.y
            ? target.position.y - Math.Sign(diffY) * followDistance.y
            : transform.position.y;

        transform.position = new Vector3(newPositionX, newPositionY, transform.position.z);
    }
}