using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShooterController : MonoBehaviour
{
    public static float propsTimer;
    public static float levelTimer;
    public static int gameLevel;
    public static bool isPlayerAlive;
    public static bool isLevelUp;
    void Start()
    {
        SetTime();
        SetLevel(StartLevel());
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
    }
    public void SetTime()
    {
        levelTimer = Time.time;
        propsTimer = Time.time;
    }

    public static int  StartLevel()
    {
        isLevelUp = false;
        return 1;
    }
    public void LevelUp()
    {
        if (Time.time > SpaceShooterController.levelTimer + 20)
        {
            isLevelUp = true;
            gameLevel++;
            SpaceShooterController.levelTimer = Time.time + 2.0f;
        }
    }
    public static int EndLevel()
    {
        return 10;
    }

    public  void SetLevel(int level)
    {
        gameLevel = level;
    }
    public static int GetHealth()
    {
        return Spaceship.health;
    }



}
