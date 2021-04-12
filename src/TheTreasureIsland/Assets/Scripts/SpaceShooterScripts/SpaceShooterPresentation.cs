using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShooterPresentation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    public GameObject spaceshipPrefab;
    GUIStyle style1 = new GUIStyle();
    GUIStyle style2 = new GUIStyle();
    public GameObject propPrefab;

    void Start()
    {
        SetBox();
        ShowSpacecraft();
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowEnemies();
        ExitMiniGfame();
        ShowProp();
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
        if (SpaceShooterController.GetHealth() == 0 || SpaceShooterController.gameLevel == SpaceShooterController.EndLevel())
        {
            GUI.Box(new Rect(750, 450, 100, 100), "Game Over\n  Score: " + SpaceShooterAbstraction.score, style2);
        }
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

    private void ShowSpacecraft()
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

    private void ExitMiniGfame()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


}
