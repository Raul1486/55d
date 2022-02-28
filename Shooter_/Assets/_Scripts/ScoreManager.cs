using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;
    
    [SerializeField]
    [Tooltip("Cantidad de puntos vida actual")]
    private int amount;

    public int Amount
    {
        get => amount;
        set => amount = value;
    }


    private void Awake()
    {
        if (SharedInstance==null)
        {
            SharedInstance = this;
        }
        else
        {
            Debug.Log("ScoreManager duplicado: debe er destruido", gameObject);
            Destroy(gameObject);
        }
    }
    
}
