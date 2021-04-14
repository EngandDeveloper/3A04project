using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
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
    }

    public void openMultipleGamePageScreen(){
        changeScene(4);
        PlayerPrefs.SetInt("gameMode", 2);
    }
    

    public void saveSettings(){

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
