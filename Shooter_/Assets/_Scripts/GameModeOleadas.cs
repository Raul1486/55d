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
    
    
    
    private void Awake()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        baseLife.onDeath.AddListener(CheckLoseCondition);
    
        EnemyManager.SharedInstance.onEnemyChanged.AddListener(CheckWinCondition);
        OleadasManager.SharedInstance.onWaveChanged.AddListener(CheckWinCondition);
    }

    void CheckLoseCondition()
    {   
        SceneManager.LoadScene(3, LoadSceneMode.Single); // cargar por puesto en gerarquia de build setting
    }

    void CheckWinCondition()
    {
        //GANAR
        if (EnemyManager.SharedInstance.EnemyCount <= 0 &&
            OleadasManager.SharedInstance.WavesCount <= 0)
        {
            SceneManager.LoadScene("WinScene", LoadSceneMode.Single); // cargar por nombre
        }
    }
}
