using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnObstacle : MonoBehaviour {
    public GameObject obstacle;
 
    public int obstacleCount = 0;
    public int obstacleLimit = 5;
    public int obstaclesPerFrame = 1;
    public float obstacleSpeed = 0.2f;
 
    void Update() {
        if (obstacleCount < obstacleLimit) {
            AddObstacle();
        }
    }
 
    void AddObstacle() {
        obstacleCount += 1;
        GameObject newObstacle = Instantiate(obstacle, new Vector2(5, 0), Quaternion.identity);
        newObstacle.transform.position = new Vector2(obstacleSpeed * Time.deltaTime, 0);
    }
}