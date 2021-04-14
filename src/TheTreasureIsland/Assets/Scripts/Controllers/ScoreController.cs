using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{

    static float p1Score = 0f; 
    static float p2Score = 0f; 

    public static void updateScore(float score){
        int player = GameController.getTurn();
        p1Score = PlayerPrefs.GetFloat("p1Score");
        p2Score = PlayerPrefs.GetFloat("p2Score");
        if(player == 1){
            p1Score += score;
            PlayerPrefs.SetFloat("p1Score", p1Score);
            Debug.Log("P1 Score: " + p1Score);
        }else if(player == 2){
            p2Score += score;
            PlayerPrefs.SetFloat("p2Score", p2Score);
            Debug.Log("P2 Score: " + p2Score);
        }
    }

    public static void resetScores(){
        p1Score = 0;
        p2Score = 0;
        PlayerPrefs.SetFloat("p1Score", p1Score);
        PlayerPrefs.SetFloat("p2Score", p2Score);
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
        // gameController = new GameController();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
