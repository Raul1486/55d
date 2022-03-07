using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
 
    public Text actualScore, actualTime, bestScore, lowTime; 
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        actualScore.text = "Score: " + PlayerPrefs.GetInt("Last Score");
        actualTime.text = "Time: " + PlayerPrefs.GetFloat("Last Time");
        bestScore.text = "Best: " + PlayerPrefs.GetInt("High Score");
        lowTime.text = "Low: " + PlayerPrefs.GetFloat("Low Time");
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level_1");
    }
}
