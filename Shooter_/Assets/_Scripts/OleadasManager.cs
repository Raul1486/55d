using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OleadasManager : MonoBehaviour
{
    public static OleadasManager SharedInstance;

    public List<WaveSpawner> oleadas;


    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            oleadas = new List<WaveSpawner>();
        }
        else
        {
            Destroy(this);
        }
    }
}
