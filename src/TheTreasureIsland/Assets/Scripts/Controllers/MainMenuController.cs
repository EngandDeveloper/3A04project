using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    public InputField p1Name;
    public InputField p2Name;

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
    

    public void saveSettings(){
        string player1Name = p1Name.text;
        string player2Name = p2Name.text;
        PlayerPrefs.SetString("p1Name", player1Name);
        PlayerPrefs.SetString("p2Name", player2Name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
