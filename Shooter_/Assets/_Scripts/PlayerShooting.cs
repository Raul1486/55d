using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shootingPoint;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _animator.SetTrigger("Disparo");
           GameObject bala = ObjectPool.SharedInstance.GetFirstPooledObject();
           bala.layer = LayerMask.NameToLayer("Bala Player");
           bala.transform.position = shootingPoint.transform.position;
           bala.transform.rotation = shootingPoint.transform.rotation;
           bala.SetActive(true);
        }
        
        
    }
}
