using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooting : MonoBehaviour
{
    private Animator _animator;

    public int bulletsAmount;
    
    public Arma arma;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.timeScale > 0)
        {
            _animator.SetTrigger("Disparo");
            if (bulletsAmount > 0 && arma.ShootBullet("Bala Player", 0.25f))
            {
                bulletsAmount--;
                if (bulletsAmount<0)
                {
                    bulletsAmount = 0;
                }
            }
        }
        
    }
}
