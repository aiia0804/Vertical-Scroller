using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameseesion : MonoBehaviour
{
    [SerializeField] int WinScorePoint = 1000;
    int CurrentScore = 0;
    Level level;

    void Awake()
    {
        SetUpSingleton();
        level = FindObjectOfType<Level>();
    }

    private void SetUpSingleton()
    {
        int ScoreLeft = FindObjectsOfType(GetType()).Length;
        if (ScoreLeft > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return CurrentScore;
    }
    public void AddScore(int screPoint)
    {
        CurrentScore += screPoint;
        if (CurrentScore > WinScorePoint)
        {
            level.LoadWinScene();
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
