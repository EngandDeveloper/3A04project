using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    float p1Score = 0f; 
    float p2Score = 0f; 

    public void updateScore(int player, float score){
        if(player == 1){
            p1Score += score;
            PlayerPrefs.SetFloat("p1Score", p1Score);
        }else if(player == 2){
            p2Score += score;
            PlayerPrefs.SetFloat("p2Score", p2Score);
        }
    }

    public float getP1Score(){
        return p1Score;
    }

    public float getP2Score(){
        return p2Score;
    }

    // Start is called before the first frame update
    void Start()
    {
        p1Score = PlayerPrefs.GetFloat("p1Score");
        p2Score = PlayerPrefs.GetFloat("p2Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
