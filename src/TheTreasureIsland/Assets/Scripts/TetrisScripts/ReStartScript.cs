using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReStart()
    {
        SceneManager.LoadScene("TetrisScene");
    }

}
