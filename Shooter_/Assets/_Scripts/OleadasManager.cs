using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OleadasManager : MonoBehaviour
{
    public static OleadasManager SharedInstance;

    private List<WaveSpawner> oleadas;

    public UnityEvent onWaveChanged;
    
    
    
    public int WavesCount
    {
        get => oleadas.Count;
    }


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

    public void AddOleada(WaveSpawner oleada)
    {
        oleadas.Add(oleada);
        onWaveChanged.Invoke();
    }
    public void RemoveOleada(WaveSpawner oleada)
    {
        oleadas.Remove(oleada);
        onWaveChanged.Invoke();
    }
    
    
}
