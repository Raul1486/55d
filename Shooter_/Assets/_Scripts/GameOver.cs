using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{

    public Text actualScore, actualTime, bestScore, bestTime; 
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        actualScore.text = "Score: " + PlayerPrefs.GetInt("Last Score");
        actualScore.text = "Time: " + PlayerPrefs.GetFloat("Last Time");
        actualScore.text = "Best: " + PlayerPrefs.GetInt("High Score");
        actualScore.text = "Best: " + PlayerPrefs.GetFloat("Low Time");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
