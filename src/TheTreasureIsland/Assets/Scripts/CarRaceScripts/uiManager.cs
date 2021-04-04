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
		//TimeElapsedText.text = "TimeElapsed: " + seconds.ToString();

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
		foreach (Button button in buttons) {
			button.gameObject.SetActive(true);
		}
	}

	public void Pause(){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			am.carSound.Stop ();
			buttons[1].gameObject.SetActive(true);
			buttons[2].gameObject.SetActive(true);
		} 
		else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			am.carSound.Play ();
			buttons[1].gameObject.SetActive(false);
			buttons[2].gameObject.SetActive(false);
		}
	}

	/*public void Replay(){
		Application.LoadLevel (Application.loadedLevel);
	}*/

	public void Menu(){
		Application.LoadLevel ("CarRaceMainMenu");
	}

	public void Play(){
		Application.LoadLevel ("CarRace");
		Time.timeScale = 1;
	}

	public void Exit(){
		Application.Quit ();
	}
}
