﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text scoreText;

    void Update()
    {
        healthText.text = FindObjectOfType<Player>().GetHealth().ToString();
        scoreText.text = FindObjectOfType<GameSession>().GetScore().ToString();
    }
}
