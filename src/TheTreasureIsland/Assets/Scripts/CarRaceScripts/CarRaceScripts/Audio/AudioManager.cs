using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource carSound;
	int isSoundOn;

	// Use this for initialization
	void Start () {
		isSoundOn = PlayerPrefs.GetInt("sound", 1);
		if(isSoundOn == 1){
			carSound.Play();
		}else if(isSoundOn == 0){
			carSound.Stop();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
