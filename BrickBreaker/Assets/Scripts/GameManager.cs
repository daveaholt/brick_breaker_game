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
            else
            {
                SceneManager.LoadScene("Menu");
            }            
        }
    }

}
