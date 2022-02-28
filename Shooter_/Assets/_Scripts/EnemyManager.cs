using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager SharedInstance;

    public List<Enemigo> enemigos;
    
    
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
}
