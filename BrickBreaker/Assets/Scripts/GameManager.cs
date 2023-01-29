using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int brickCount;
    private bool isStarted;

    private void Awake()
    {
        instance = this;
        isStarted = false;
        brickCount = 0;
    }

    void Start()
    {
        isStarted = true;
    }


    void Update()
    {
        CheckLevelComplete();
    }

    private void CheckLevelComplete()
    {
        if(isStarted && brickCount == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
