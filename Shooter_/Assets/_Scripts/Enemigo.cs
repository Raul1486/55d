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


    private void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(DestroyEnemy);
    }


    private void Start()
    {
        EnemyManager.SharedInstance.AddEnemy(this); //registra al enemigo nuevo y se suma
    }

    private void DestroyEnemy()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Play Die");
                
        Invoke("PlayDestruction", 1);
        Destroy(gameObject,1.5f);

        EnemyManager.SharedInstance.RemoveEnemy(this);
        ScoreManager.SharedInstance.Amount += pointsAmount;
    }


    private void OnDestroy()
    {
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(DestroyEnemy);
    }

    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}
