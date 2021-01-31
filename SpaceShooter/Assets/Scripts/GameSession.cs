using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int score = 0;

    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            ResetGame();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }            
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
