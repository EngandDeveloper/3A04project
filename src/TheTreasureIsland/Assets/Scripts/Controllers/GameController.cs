using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    int gameMode = 1; //Single Player: 1, Multi Player: 2
    int turn = 1; //Which players turn it is

    public void changeScene(int index){
        SceneManager.LoadScene(index);
    }

    public void startFirstGame(){
        changeScene(5);
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
