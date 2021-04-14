﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameController : MonoBehaviour
{
    public Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        int gameMode = PlayerPrefs.GetInt("gameMode", 1);
        string p1Name = PlayerPrefs.GetString("p1Name");
        float p1Score = PlayerPrefs.GetFloat("p1Score");
        if(gameMode == 1){
            resultText.text = "Player: " + p1Name + " --- Score: " + p1Score;
        }else if(gameMode == 2){
            string p2Name = PlayerPrefs.GetString("p2Name");
            float p2Score = PlayerPrefs.GetFloat("p2Score");
            string winner = "";
            if(p1Score > p2Score){
                winner = p1Name;
            }else if(p2Score > p1Score){
                winner = p2Name;
            }else if(p1Score == p2Score){
                winner = "Tie";
            }
            resultText.text = "Player1: " + p1Name + " --- Score: " + p1Score + "\n Player2: " + p2Name + " --- Score: " + p2Score + "\n Winner: " + winner;
        }
        ScoreController.validateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
