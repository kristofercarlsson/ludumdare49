using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SpawnObstacle : MonoBehaviour {
    public Transform startMarker;
    public Transform endMarker;
    public GameObject obstacle;
    private float speed = 10.0F;
    private float startTime;
    private float journeyLength;
    private GameObject newObstacle;

    void Start() {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        newObstacle = Instantiate(obstacle, startMarker.position, Quaternion.identity);
    }

    void Update() {
        if (newObstacle == null && !ReferenceEquals(newObstacle, null)) {
            newObstacle = Instantiate(obstacle, startMarker.position, Quaternion.identity);
        }
        if (newObstacle.transform.position.x == endMarker.position.x) {
            Destroy(newObstacle);
        }
        if (newObstacle.activeSelf) {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            newObstacle.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
    }
}