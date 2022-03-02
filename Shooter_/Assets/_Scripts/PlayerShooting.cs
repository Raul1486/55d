using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shootingPoint;

    private Animator _animator;

    public int bulletsAmount;
    
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsAmount > 0 && Time.timeScale > 0)
        {
            _animator.SetTrigger("Disparo");
            Invoke("FireBullet", 0.25f);
        }
    }

    void FireBullet()
    {
        GameObject bala = ObjectPool.SharedInstance.GetFirstPooledObject();
        bala.layer = LayerMask.NameToLayer("Bala Player");
        bala.transform.position = shootingPoint.transform.position;
        bala.transform.rotation = shootingPoint.transform.rotation;
        bala.SetActive(true);

        bulletsAmount--;
    }
}
