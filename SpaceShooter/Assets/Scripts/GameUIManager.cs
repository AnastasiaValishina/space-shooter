using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    Player player;
    GameSession gameSession;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        gameSession = FindObjectOfType<GameSession>();
    }
    void Update()
    {
        if (player)
        {
            healthText.text = player.GetHealth().ToString();
        }

        scoreText.text = gameSession.GetScore().ToString();
    }
}
