using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnObstacle : MonoBehaviour {
    public Transform startMarker;
    public Transform endMarker;
    public GameObject template;
    public float moveSpeed;
    
    private GameObject obstacle;
    
    void Update() {
        if (obstacle == null) {
            obstacle = Instantiate(template, startMarker.position, Quaternion.identity);
            obstacle.AddComponent<MoveObstacle>();
            var script = obstacle.GetComponent<MoveObstacle>();

            var directionX = Math.Sign(endMarker.position.x - startMarker.position.x);
            script.startVelocity = directionX * moveSpeed;
            return;
        }

        var diff = Math.Abs(obstacle.transform.position.x - endMarker.position.x);
        if (diff < 0.5f) {
            Destroy(obstacle);
            obstacle = null;
            return;
        }
    }
}