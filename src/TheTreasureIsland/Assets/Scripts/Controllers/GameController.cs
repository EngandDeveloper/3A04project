using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    static int gameMode = 1; //Single Player: 1, Multi Player: 2
    static int turn = 1; //Which players turn it is
    static int island = 1; //Which mini game (island) the players are on
    static bool isTurnEnded = false;
    public Text turnText;
    string player1Name;
    string player2Name;

    public void changeScene(int index){
        SceneManager.LoadScene(index);
    }

    public static void gamePageScreen(){
        SceneManager.LoadScene(4);
    }

    public void exitGamePageScreen(){
        changeScene(4);
    }

    public void startFirstGame(){
        changeScene(5);
    }

    public void startSecondGame(){
        changeScene(8);
    }

    public void startThirdGame(){
        changeScene(9);
    }

    public void startForthGame(){
        changeScene(6);
    }

    public void startFifthGame(){
        changeScene(5);
    }

    public static void resetGame(){
        ScoreController.resetScores();
        turn = 1;
        island = 1;
        isTurnEnded = false;
        PlayerPrefs.SetInt("turn", 1);
        PlayerPrefs.SetInt("island", 1);
        PlayerPrefs.SetInt("tEnds", 0);
    }

    public static void endTurn(){
        isTurnEnded = true;
        PlayerPrefs.SetInt("tEnds", 1);
        turn = getTurn();
        if(gameMode == 2){
            if(turn == 1 && isTurnEnded){
                turn = 2;
                PlayerPrefs.SetInt("turn", 2);
                Debug.Log("Turn is: " + turn);
                isTurnEnded = false;
                PlayerPrefs.SetInt("tEnds", 0);
            }else if(turn == 2 && isTurnEnded){
                turn = 1;
                PlayerPrefs.SetInt("turn", 1);
                Debug.Log("Turn 1 is: " + turn);
                isTurnEnded = false;
                PlayerPrefs.SetInt("tEnds", 0);
                //Move to the next island
                island = PlayerPrefs.GetInt("island", 1);
                if(island != 6){
                    island += 1;
                    PlayerPrefs.SetInt("island", island);
                }else{
                    Debug.Log("Game Ended");
                    //TODO: Call End Game Result Page + Show game ended
                }
            }
        }else if(gameMode == 1){
            if(isTurnEnded){
                turn = 1;
                PlayerPrefs.SetInt("turn", 1);
                island = PlayerPrefs.GetInt("island", 1);
                isTurnEnded = false;
                PlayerPrefs.SetInt("tEnds", 0);
                if(island != 6){
                    island += 1;
                    PlayerPrefs.SetInt("island", island);
                }else{
                    Debug.Log("Game Ended");
                    //TODO: Call End Game Result Page + Show game ended
                }
            }
        }
    }

    public static int getTurn(){
        turn = PlayerPrefs.GetInt("turn");
        return turn;
    }

    public void updateTurnText(){
        turn = getTurn();
        island = PlayerPrefs.GetInt("island", 1);
        Debug.Log("update turn is: " + turn);
        if(turn == 1){
            turnText.text = "It is the " + player1Name + "'s turn. Island: " + island;
        }else if(turn == 2){
            turnText.text = "It is the " + player2Name + "'s turn. Island: " + island;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameMode = PlayerPrefs.GetInt("gameMode");
        Debug.Log("Game Mode is: " + gameMode);
        player1Name = PlayerPrefs.GetString("p1Name", "Player 1");
        player2Name = PlayerPrefs.GetString("p2Name", "Player 2");
        // PlayerPrefs.SetInt("turn", 1);
        updateTurnText();
    }

    // Update is called once per frame
    void Update()
    {
        int tEnds = PlayerPrefs.GetInt("tEnds");
        if(tEnds == 1){
            isTurnEnded = true;
        }else if(tEnds == 0){
            isTurnEnded = false;
        }
        // updateTurnText();
        if(isTurnEnded){
            updateTurnText();
        }
    }
    //TO Fix git
}
