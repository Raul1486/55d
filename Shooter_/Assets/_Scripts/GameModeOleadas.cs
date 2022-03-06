using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //esta la pongo manual para poder cargar escenas en unity

public class GameModeOleadas : MonoBehaviour
{
    [SerializeField] 
    private Life playerLife;

    [SerializeField] 
    private Life baseLife;
    
    
    
    private void Start()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        baseLife.onDeath.AddListener(CheckLoseCondition);
    
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(CheckWinCondition);
        OleadasManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }

    void CheckLoseCondition()
    {
        RegisterScore();
        RegisterTime();
        SceneManager.LoadScene(3, LoadSceneMode.Single); // cargar por puesto en gerarquia de build setting
    }

    void CheckWinCondition()
    {
        //GANAR
        if (EnemyManager.SharedInstance.EnemyCount <= 0 &&
            OleadasManager.SharedInstance.WavesCount <= 0)
        {
            RegisterScore();
            RegisterTime();
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single); // cargar por nombre
        }
    }
    
    
    
    void RegisterScore()
    {
        var actualScore = ScoreManager.SharedInstance.Amount;
        PlayerPrefs.SetInt("Last Score", actualScore);

        var highScore = PlayerPrefs.GetInt("High Score", 0);
        
        if (actualScore > highScore)
        {
            PlayerPrefs.SetInt("High Score", actualScore);
        }

    }

    void RegisterTime()
    {
        var actualTime = Time.time;
        PlayerPrefs.SetFloat("Last Time", actualTime);

        var lowTime = PlayerPrefs.GetFloat("low Time", 9999999.0f);
        
        if (actualTime < lowTime)
        {
            PlayerPrefs.SetFloat("Low Time", actualTime);
        }
    }

}
