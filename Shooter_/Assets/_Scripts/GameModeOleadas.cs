using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //esta la pongo manual para poder cargar escenas en unity

public class GameModeOleadas : MonoBehaviour
{
    [SerializeField] private Life playerLife;

    void Update()
    {
     //GANAR
     if (EnemyManager.SharedInstance.enemigos.Count <= 0 &&
         OleadasManager.SharedInstance.oleadas.Count <= 0)
     {
         SceneManager.LoadScene("WinScene", LoadSceneMode.Single); // cargar por nombre
     }

     //PERDER
     if (playerLife.Amount <=0)
     {
         SceneManager.LoadScene(3, LoadSceneMode.Single); // cargar por puesto en gerarquia de build setting
     }
     
     
    }
}
