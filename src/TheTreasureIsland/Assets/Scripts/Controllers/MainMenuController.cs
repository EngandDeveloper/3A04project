using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public InputField p1Name;
    public InputField p2Name;
    string player1Name;
    string player2Name;
    public Text soundText;
    int sound = 1;

    public void changeScene(int index){
        SceneManager.LoadScene(index);
    }

    public void openMainMenuScreen(){
        changeScene(0);
    }

    public void openSettingsScreen(){
        changeScene(1);
    }
    
    public void openTutorialScreen(){
        changeScene(2);
    }

    public void openHighScoreScreen(){
        changeScene(3);
    }

    public void openGamePageScreen(){
        changeScene(4);
        PlayerPrefs.SetInt("gameMode", 1);
        GameController.resetGame();
    }

    public void openMultipleGamePageScreen(){
        changeScene(4);
        PlayerPrefs.SetInt("gameMode", 2);
        GameController.resetGame();
    }
    
    public void getPlayer1Input(){
        player1Name = p1Name.text;
        Debug.Log("P1 Name Got As: " + player1Name);
        
    }

    public void getPlayer2Input(){
        player2Name = p2Name.text;
        Debug.Log("P2 Name Got As: " + player2Name);
    }

    public void saveSoundSettings(){
        sound = PlayerPrefs.GetInt("sound");
        if(sound == 1){
            sound = 0;
            PlayerPrefs.SetInt("sound", 0);
            soundText.text = "Sound Off";
        }else if(sound == 0){
            sound = 1;
            PlayerPrefs.SetInt("sound", 1);
            soundText.text = "Sound On";
        }
    }

    public void saveSettings(){
        // player1Name = p1Name.text;
        // player2Name = p2Name.text;
        PlayerPrefs.SetString("p1Name", player1Name);
        PlayerPrefs.SetString("p2Name", player2Name);
        Debug.Log("P1 Name: " + player1Name);
        Debug.Log("P2 Name: " + player2Name);
    }

    // Start is called before the first frame update
    void Start()
    {
        sound = PlayerPrefs.GetInt("sound", 1);
        if(sound == 1){
            soundText.text = "Sound On";
        }else if(sound == 0){
            soundText.text = "Sound Off";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
