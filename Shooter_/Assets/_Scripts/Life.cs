using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.Rendering;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;

    public float Amount
    {
        get => amount;
        
        
        set
        {
            amount = value;
            
            if (amount <= 0)
            {
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Play Die");
                
                Invoke("PlayDestruction", 1);    

                Destroy(gameObject,1.5f);
            }
        }
    }
    
    void PlayDestruction()
    {
        ParticleSystem explosion = GetComponentInChildren<ParticleSystem>();
        explosion.Play();
    }
}
