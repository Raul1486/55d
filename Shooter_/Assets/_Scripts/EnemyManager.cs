using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    private List<Enemigo> enemigos;
    public UnityEvent onEnemyChanged;
    
    
    public int EnemyCount
    {
        get => enemigos.Count;
    }
    
    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            enemigos = new List<Enemigo>();
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddEnemy(Enemigo enemigo)
    {
        enemigos.Add(enemigo);
        onEnemyChanged.Invoke();
    }
    public void RemoveEnemy(Enemigo enemigo)
    {
        enemigos.Remove(enemigo);
        onEnemyChanged.Invoke();
    }
    
}
