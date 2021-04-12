using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatternMatchingController : MonoBehaviour
{

    //***** Button Declarations Start *****\\
    public Button B0;    
    public Button B1;    
    public Button B2;    
    public Button B3;    
    public Button B4;    
    public Button B5;    
    public Button B6;    
    public Button B7;    
    public Button B8;    
    public Button B9;    
    public Button B10;    
    public Button B11;    
    public Button B12;    
    public Button B13;    
    public Button B14;    
    public Button B15;    
    //***** Button Declarations End *****\\

    //***** Variables Start *****\\
    public Button[] buttons;
    int[] answerMap;
    private int[] currentMap;
    bool isFirst = true; //use it to show the pattern
    bool isTrue; //use it to check the player answer correctness
    PatternMatchingAbstraction abstraction;
    //***** Variables End *****\\


    IEnumerator showPattern(){
        abstraction.generatePattern();
        currentMap = abstraction.getPatternMap();
        
        /* Debug logs to see the current map generation*/
        // Debug.Log("Current Map is:");
        
        // for(int i = 0; i < currentMap.Length; i++){
        //     Debug.Log(currentMap[i]);
        // }

        for(int i = 0; i < currentMap.Length; i++){
            if(currentMap[i] == 1){
                ColorBlock c = buttons[i].GetComponent<Button>().colors;
                c.normalColor = Color.red;
                buttons[i].colors = c;
                // Set the color back to its original color after wait time
                float x = 1f;
                float r = (61f/255f);
                float g = (126f/255f);
                float b = (236f/255f);
                yield return new WaitForSeconds(x);
                c.normalColor = new Color(r, g, b, 1);
                buttons[i].colors = c;
            }
        }
    }


    // public void onStartLevelClicked(){
    //     StopCoroutine("showPattern");
    //     StartCoroutine("showPattern");
    //     isFirst = false;
    // }

    /**
    * @brief get the id of the button pressed and assign it to the answerMap
    */
    public void getButtonId(int btnIndex){
        answerMap[btnIndex] = 1; //Set the answer
        Debug.Log(btnIndex);
    }

    /**
    * @brief check player's answer against the currentMap
    */
    public void checkAnswer(){
        isTrue = true;
        for(int i = 0; i < currentMap.Length; i++){
            if(currentMap[i] != answerMap[i]){
                isTrue = false;
                break;
            }
        }
        Debug.Log(isTrue);
        //TODO: Based on the result congragulate the user or restart the game
    }

    /**
    * @brief reset player answers
    */
    public void resetAnswerMap(){
        for(int i = 0; i < answerMap.Length; i++){
            answerMap[i] = 0;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        buttons = new Button[] {B0, B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12, B13, B14, B15};
        answerMap = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
        abstraction = new PatternMatchingAbstraction();

        // currentMap = new int[] {0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1};
        // StopCoroutine("showPattern");    // Interrupt in case it's running
        // StartCoroutine("showPattern");
    }

    // Update is called once per frame
    void Update()
    {
        if(isFirst){
            StopCoroutine("showPattern");    // Interrupt in case it's running
            StartCoroutine("showPattern");
            isFirst = false;
        }
    }

}
