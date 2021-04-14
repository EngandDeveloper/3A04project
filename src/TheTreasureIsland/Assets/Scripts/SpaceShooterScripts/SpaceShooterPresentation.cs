using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShooterPresentation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject spaceshipPrefab;
    public GameObject enemyBossPrefab;
    GUIStyle style1 = new GUIStyle();
    GUIStyle style2 = new GUIStyle();
    public GameObject propPrefab;
    private bool enemyBossShow=true;
    public static bool isReStart;


    void Start()
    {
        SetBox();
        ShowSpacecraft();
        EnemyStart();

    }

    // Update is called once per frame
    void Update()
    {
        ShowEnemies();
        ExitMiniGfame();
        ShowProp();
        ShowEnemyBoss();
        // reStart();
        endGame();
    }

    private void SetBox()
    {
        style1.fontSize = 50;
        style1.normal.textColor = Color.white;
        style2.fontSize = 100;
        style2.normal.textColor = Color.red;
        Font myFont = (Font)Resources.Load("Fonts/comic", typeof(Font));
    }




    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 100, 100), "Score: " + SpaceShooterAbstraction.GetScore() + "\n" + "Lives: " + SpaceShooterController.GetHealth() + "\n" + "game level: "+ SpaceShooterController.gameLevel+ "\n" + "spaceship level: "+ Spaceship.GetShipLevel(), style1);
        if (EnemyBoss.IsDestroy())
        {
            SpaceShooterController.gameOver();
            GUI.Box(new Rect(750, 450, 100, 100), "Game Over\n  Score: " + SpaceShooterAbstraction.score, style2);
        }
    }

    private void EnemyStart()
    {
        Instantiate(enemyPrefab);
        Instantiate(enemyPrefab);
    }
    private void ShowEnemies()
    {
        if (Enemy.IsDestroy())
        {
            Instantiate(enemyPrefab);

        }
        if (SpaceShooterController.isLevelUp)
        {
            Instantiate(enemyPrefab);
            SpaceShooterController.isLevelUp = false;
        }
    }

    public void ShowSpacecraft()
    {
        Instantiate(spaceshipPrefab);
    }

    private void ShowProp()
    {
        if (Time.time > SpaceShooterController.propsTimer + 15 && Spaceship.GetShipLevel() != 2)
        {
            Instantiate(propPrefab);
            SpaceShooterController.propsTimer = Time.time + 2.0f;
        }
    }

    private void ShowEnemyBoss()
    {
        if (SpaceShooterController.gameLevel == SpaceShooterController.EndLevel() && enemyBossShow)
        {
            Instantiate(enemyBossPrefab);
            enemyBossShow = false;
        }
    }

    private void ExitMiniGfame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void reStart()
    {

        SpaceShooterController.SetTime();
        SpaceShooterController.gameLevel = 1;
        SpaceShooterController.SetTime();
        var enemy = GameObject.FindGameObjectsWithTag("enemy");
        var laser1 = GameObject.FindGameObjectsWithTag("laser1");
        var laser2 = GameObject.FindGameObjectsWithTag("laser2");
        foreach (var clone in enemy)
        {
            Destroy(clone);
        }
        foreach (var clone in laser2)
        {
            Destroy(clone);
        }
        foreach (var clone in laser1)
        {
            Destroy(clone);
        }

        Instantiate(spaceshipPrefab);
        Instantiate(enemyPrefab);
        Instantiate(enemyPrefab);

    }

    public void endGame(){
        if (SpaceShooterController.GetHealth() <= 0)
        {
            float pScore = (float) SpaceShooterAbstraction.score;
            ScoreController.updateScore(pScore);
            GameController.endTurn();
            reStart();
            SceneManager.LoadScene(7);
        }
    }


}
