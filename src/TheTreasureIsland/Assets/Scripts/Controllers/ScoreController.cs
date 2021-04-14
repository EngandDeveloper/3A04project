using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public Text h1Text;
    public Text h2Text;
    public Text h3Text;
    public Text h4Text;
    public Text h5Text;
    public Text h6Text;
    public Text h7Text;
    public Text h8Text;
    public Text h9Text;
    public Text h10Text;

    static float p1Score = 0f; 
    static float p2Score = 0f; 
    static float[] highScores = {0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f};
    static string[] highNames = {"None", "None", "None", "None", "None", "None", "None", "None", "None", "None"};
    Text[] texts;

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

    public void getHighScores(){
        highScores[0] = PlayerPrefs.GetFloat("h1", 0f);
        highScores[1] = PlayerPrefs.GetFloat("h2", 0f);
        highScores[2] = PlayerPrefs.GetFloat("h3", 0f);
        highScores[3] = PlayerPrefs.GetFloat("h4", 0f);
        highScores[4] = PlayerPrefs.GetFloat("h5", 0f);
        highScores[5] = PlayerPrefs.GetFloat("h6", 0f);
        highScores[6] = PlayerPrefs.GetFloat("h7", 0f);
        highScores[7] = PlayerPrefs.GetFloat("h8", 0f);
        highScores[8] = PlayerPrefs.GetFloat("h9", 0f);
        highScores[9] = PlayerPrefs.GetFloat("h10", 0f);
        highNames[0] = PlayerPrefs.GetString("n1", "None");
        highNames[1] = PlayerPrefs.GetString("n2", "None");
        highNames[2] = PlayerPrefs.GetString("n3", "None");
        highNames[3] = PlayerPrefs.GetString("n4", "None");
        highNames[4] = PlayerPrefs.GetString("n5", "None");
        highNames[5] = PlayerPrefs.GetString("n6", "None");
        highNames[6] = PlayerPrefs.GetString("n7", "None");
        highNames[7] = PlayerPrefs.GetString("n8", "None");
        highNames[8] = PlayerPrefs.GetString("n9", "None");
        highNames[9] = PlayerPrefs.GetString("n10", "None");
        for(int i = 0; i < highScores.Length; i++){
            Debug.Log(i + ": " + highNames[i]);
        }
    }

    public void generateHighScoreTable(){
        getHighScores();
        for(int i = 0; i < texts.Length; i++){
            int index = i+1;
            texts[i].text = " " + index + " --- " + highNames[i] + " --- " + highScores[i];
        }
        reorderTable();
    }

    public static bool validateHighScore(){
        bool isHighScore = false;
        float s1 = PlayerPrefs.GetFloat("p1Score");
            isHighScore = checkHighScore(s1, 1);
        int gameMode = PlayerPrefs.GetInt("gameMode", 1);
        if(gameMode == 2){
            float s2 = PlayerPrefs.GetFloat("p2Score");
            isHighScore = checkHighScore(s2, 2);
        }
        return isHighScore;
    }

    public static bool checkHighScore(float score, int player){
        string playerName = PlayerPrefs.GetString("p1Name");
        if(player == 2){
            playerName = PlayerPrefs.GetString("p2Name");
        }
        for(int i = 0; i < highScores.Length; i++){
            if(highScores[i] < score){
                highScores[i] = score;
                highNames[i] = playerName;
                string high1 = "h" + (i+1);
                string name1 = "n" + (i+1);
                Debug.Log(high1 + name1);
                PlayerPrefs.SetFloat(high1, score);
                PlayerPrefs.SetString(name1, playerName);
                return true;
            }
        }
        return false;
    }

    public void reorderTable(){
        for(int i = 9; i >= 0; i--){
            if(i != 0){
                if(highScores[i] > highScores[i-1]){
                    string high1 = "h" + i;
                    string name1 = "n" + i;
                    string high2 = "h" + (i+1);
                    string name2 = "n" + (i+1);
                    float temp = highScores[i-1];
                    float temp2 = highScores[i];
                    highScores[i-1] = temp2;
                    highScores[i] = temp;
                    PlayerPrefs.SetFloat(high1, temp2);
                    PlayerPrefs.SetFloat(high2, temp);
                    string tName = highNames[i-1];
                    string tName2 = highNames[i];
                    highNames[i-1] = highNames[i];
                    highNames[i] = tName;
                    Debug.Log(high1 + name1);
                    Debug.Log(high2 + name2);
                    PlayerPrefs.SetString(name1, tName2);
                    PlayerPrefs.SetString(name2, tName);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        p1Score = PlayerPrefs.GetFloat("p1Score");
        p2Score = PlayerPrefs.GetFloat("p2Score");
        texts = new Text[] {h1Text, h2Text, h3Text, h4Text, h5Text, h6Text, h7Text, h8Text, h9Text, h10Text};
        generateHighScoreTable();
        // gameController = new GameController();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //To fix git
}
