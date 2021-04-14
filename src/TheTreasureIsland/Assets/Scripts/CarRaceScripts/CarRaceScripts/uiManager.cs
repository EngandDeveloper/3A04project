using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public Button[] buttons;
	bool gameOver;
	public Text scoreText;
	public AudioManager am;
	public int score;
 	double seconds = 0.01;

	// Use this for initialization
	void Start () {
		gameOver = false;
		score = 0;
		InvokeRepeating ("TimeUpdate", 0.01f, 0.01f);
		InvokeRepeating ("scoreUpdate", 1.25f, 0.75f);
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + score +"\n\n" + "Time: " + Math.Round(seconds, 2, MidpointRounding.ToEven).ToString();

	}

	void TimeUpdate () {
		if (gameOver == false) {
			seconds += 0.01;
		}
	}

	void scoreUpdate(){
		if (gameOver == false) {
			score += 1;
		}

	}

	public double getElapsedTime(){
		return Math.Round(seconds, 2, MidpointRounding.ToEven);
	}

	public void gameOverActivated(){
		gameOver = true;
		Debug.Log(getElapsedTime());
		float FinalScore = (4000/((float)getElapsedTime())) + 200.0f;
		ScoreController.updateScore(FinalScore);
        GameController.endTurn();
		//////////////////////
		//////////////////////
		//////GameEnded///////
		//////////////////////
		//////////////////////
	}

	public void Pause(){
		Application.LoadLevel ("GamePageScreen");
	}

}
