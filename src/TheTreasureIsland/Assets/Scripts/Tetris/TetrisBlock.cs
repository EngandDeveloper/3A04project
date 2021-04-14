using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TetrisBlock : MonoBehaviour
{
    public Vector3 rotationPoint;
    private float previousTime;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;
    private static Transform[,] grid = new Transform[width, height];

    public int scoreOneLine = 10;
    public int scoreTwoLines = 25;
    public int scoreThreeLines = 50;
    public int scoreFourLines = 100;
    private int numberOfRowsThisTurn = 0;
    public float maxScore = 1000;
    public float minScore = 100;
    public float currentScore;
    public bool isabove = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isabove = CheckIsAboveGrid();
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if(!ValidMove())
                transform.position -= new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMove())
                transform.position -= new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //rotate !
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0,0,1), 90);
            if (!ValidMove())
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
        }


        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (isabove){
                    GameOver();
                }
            if (!ValidMove())
            {
                
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckForLines();
                if (ScoreScript.scoreValue >= 10){
                    updateScore();
                    ScoreController.updateScore(currentScore);
                    GameController.endTurn();
                    GameOver();
                }
                
                this.enabled = false;
                FindObjectOfType<SpawnTetromino>().NewTetromino();

            }
            previousTime = Time.time;
        }

    }

    public void updateScore()
    {
        int x = (int) TimerController.t/10;
        currentScore = maxScore - 10*x;
        if (currentScore < minScore){
            currentScore = minScore;
        }
    }


    void CheckForLines()
    {
        for (int i = height-1; i >= 0; i--)
        {
            if(HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for(int j = 0; j< width; j++)
        {
            if (grid[j, i] == null)
                return false;
        }
        ScoreScript.scoreValue++;
        return true;
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int j = 0; j < width; j++)
            {
                if(grid[j,y] != null)
                {
                    grid[j, y - 1] = grid[j, y];
                    grid[j, y] = null;
                    grid[j, y - 1].transform.position -= new Vector3(0, 1, 0);
                }
            }
        }
    }


    bool CheckIsAboveGrid(){
        for (int x = 0; x < width; ++x){
            foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                if(roundedY >= height)
                {
                    return true;
                }
            }
        }    
        return false;
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            grid[roundedX, roundedY] = children;
        }
    }

    bool ValidMove()
    {
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);

            if(roundedX < 0 || roundedX >= width || roundedY < 0 ||roundedY >= height)
            {
                return false;
            }

            if (grid[roundedX, roundedY] != null)
                return false;
        }

        return true;
    }

    public void GameOver(){
        SceneManager.LoadScene("TetrisGameOver");
    }
}
