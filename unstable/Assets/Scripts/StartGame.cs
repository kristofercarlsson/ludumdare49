using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump") )
        {
            SceneManager.LoadScene (sceneName:"Game");
        }
    }
}
