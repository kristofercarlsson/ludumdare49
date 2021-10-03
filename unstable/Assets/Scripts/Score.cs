using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //its a must to access new UI in script

public class Score : MonoBehaviour
{
    
    public Text ourComponent;
    public static float score = 0;
    private float multiplier = 1;
    private int tickRate = 120;
    private int currentTick = 0;

    // Start is called before the first frame update
    void Start()
    {
        ourComponent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentTick == tickRate)
        {
            multiplier = multiplier * 1.2f;
            UpdateScore();
            currentTick = 0;
        }
        else
        {
            currentTick++;
        }
    }

    private void UpdateScore()
    {
        score = score + 1 * multiplier;
        ourComponent.text = "Score: " + (int)score;
    }
}