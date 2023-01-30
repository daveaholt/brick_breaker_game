using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int brickCount;
    private bool isStarted;

    [SerializeField]
    public BrickBreakerState BrickBreakerState;

    public int Score
    {
        get
        {
            return BrickBreakerState.Score;
        }
        set
        {
            BrickBreakerState.Score = value;
        }
    }

    private void Awake()
    {
        instance = this;
        isStarted = false;
        brickCount = 0;
    }

    void Start()
    {
        isStarted = true;
        BrickBreakerState.CurrentLevel = SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        CheckLevelComplete();
    }

    private void CheckLevelComplete()
    {
        if(isStarted && brickCount == 0)
        {
            if(BrickBreakerState.CurrentLevel == "Level_1")
            {
                SceneManager.LoadScene("Level_2");
            }
            else if(BrickBreakerState.CurrentLevel == "Level_2")
            {
                SceneManager.LoadScene("Level_3");
            }
            else if(BrickBreakerState.CurrentLevel == "Level_3")
            {
                SceneManager.LoadScene("Level_4");
            }
            else if(BrickBreakerState.CurrentLevel == "Level_4")
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
