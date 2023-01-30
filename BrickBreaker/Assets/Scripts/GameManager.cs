using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int brickCount;
    private bool isStarted;

    public int Score;

    private void Awake()
    {
        instance = this;
        isStarted = false;
        brickCount = 0;
    }

    void Start()
    {
        isStarted = true;
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            Score = 0;
        }
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Score = 30;
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            Score = 60;
        }
        else if (SceneManager.GetActiveScene().name == "Level_4")
        {
            Score = 90;
        }
        else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            Score = 120;
        }
    }


    void Update()
    {
        CheckLevelComplete();
    }

    private void CheckLevelComplete()
    {
        if(isStarted && brickCount == 0)
        {
            if(SceneManager.GetActiveScene().name == "Level_1")
            {
                SceneManager.LoadScene("Level_2");
            }
            else if(SceneManager.GetActiveScene().name == "Level_2")
            {
                SceneManager.LoadScene("Level_3");
            }
            else if(SceneManager.GetActiveScene().name == "Level_3")
            {
                SceneManager.LoadScene("Level_4");
            }
            else if(SceneManager.GetActiveScene().name == "Level_4")
            {
                SceneManager.LoadScene("Level_5");
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }            
        }
    }

}
