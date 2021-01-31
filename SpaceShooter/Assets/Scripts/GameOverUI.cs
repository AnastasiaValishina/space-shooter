using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] Text scoreText;

    void Update()
    {
        scoreText.text = FindObjectOfType<GameSession>().GetScore().ToString();
    }
}
