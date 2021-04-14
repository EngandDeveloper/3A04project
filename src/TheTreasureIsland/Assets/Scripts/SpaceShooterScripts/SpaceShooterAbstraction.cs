using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShooterAbstraction : MonoBehaviour
{
    public static int score;
    void Start()
    {
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScore()
    {
        score = 0;
    }
    public static int GetScore()
    {
        return score;
    }



}
