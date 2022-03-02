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

    private int maxOleadas;
    public int MaxOleadas
    {
        get => maxOleadas;
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
        maxOleadas++;
        oleadas.Add(oleada);
        onWaveChanged.Invoke();
    }
    public void RemoveOleada(WaveSpawner oleada)
    {
        oleadas.Remove(oleada);
        onWaveChanged.Invoke();
    }
    
    
}
