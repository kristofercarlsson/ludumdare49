using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text highScore;
    void Start()
    {
        highScore = GetComponent<Text>();
        highScore.text = "Score: " + (int)Score.score;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") )
        {
            SceneManager.LoadScene (sceneName:"Menu");
        }
    }
}
