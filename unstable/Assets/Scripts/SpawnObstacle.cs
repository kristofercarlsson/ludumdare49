using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnObstacle : MonoBehaviour {
    public Transform startMarker;
    public Transform endMarker;
    public GameObject template;
    
    private GameObject obstacle;
    
    void Update() {
        if (obstacle == null) {
            Debug.Log("Create obstacle");
            obstacle = Instantiate(template, startMarker.position, Quaternion.identity);
            obstacle.AddComponent<MoveObstacle>();
            var script = obstacle.GetComponent<MoveObstacle>();
            script.startVelocity = -5;
            return;
        }

        var diff = Math.Abs(obstacle.transform.position.x - endMarker.position.x);
        if (diff < 0.5f) {
            Debug.Log("Destroy obstacle");
            Destroy(obstacle);
            obstacle = null;
            return;
        }
    }
}