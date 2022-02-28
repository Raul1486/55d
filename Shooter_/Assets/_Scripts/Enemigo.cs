using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    
    [SerializeField]
    [Tooltip("Cantidad de puntos que se obtienen al derrotar al enemigo")]
    private int pointsAmount = 10;

    
    
    private void Start()
    {
        EnemyManager.SharedInstance.enemigos.Add(this); //registra al enemigo nuevo y se suma
    }

    private void OnDestroy()
    {
        EnemyManager.SharedInstance.enemigos.Remove(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }
}
