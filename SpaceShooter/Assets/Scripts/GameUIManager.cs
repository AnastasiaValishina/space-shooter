using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
 
    void Update()
    {
        scoreText.text = FindObjectOfType<Player>().GetHealth().ToString();
    }
}
