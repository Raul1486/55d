using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SocialPlatforms;


[RequireComponent(typeof(Rigidbody))] //ESTO METE UN RIGIGBODY A
                                      //TODOS EL QUE USE ESTE SCRIPT
public class PlayerMovement : MonoBehaviour

{
    [Tooltip("Fuerza del Mov. del Personaje en N/s")]
    [Range(0, 1000)]
    public float speed;
    
    [Tooltip("Fuerza de rotacion de la camara del jugador en N/seg")]
    [Range(0,360)]
    public float rotationSpeed;


    private Rigidbody _rb;
    private  Animator _animator;
    
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        _rb = GetComponent<Rigidbody>(); //ESTO ES SIEMPRE EN EL START
        _animator = GetComponent<Animator>();

    }

    void Update()
{
    float space = speed * Time.deltaTime;
    float horizontal = Input.GetAxis("Horizontal"); // -1 a 1
    float vertical = Input.GetAxis("Vertical"); // -1 a 1

    Vector3 dir = new Vector3(horizontal, 0, vertical);
    //transform.Translate(dir.normalized * space);
    // SUSTITUIR X FUERZA DE TRASLACION
    _rb.AddRelativeForce(dir.normalized * space);
    
    float angle = rotationSpeed * Time.deltaTime;
    float mouseX = Input.GetAxis("Mouse X"); // -1 a 1
    //float mouseY = Input.GetAxis("Mouse Y"); // -1 a 1
    
    //transform.Rotate(0, mouseX * angle, 0);
    // SUSTITUIR X FUERZA ROTACION <-> TORQUE
    _rb.AddRelativeTorque(0, mouseX * angle, 0);

    _animator.SetFloat("Velocity", _rb.velocity.magnitude);
    
    
    //ESTE CODIGO SIRVE PARA IR DE PARADO A ANDAR, LUEGO A CORRER Y VICEVERSA...
    /*
    _animator.SetFloat("MoveX", horizontal);
    _animator.SetFloat("MoveY", vertical);

    if (Input.GetKey(KeyCode.LeftShift))
    {
        _animator.SetFloat("Velocity", _rb.velocity.magnitude);    
    }
    else
    {
        if (Math.Abs(horizontal)<0.01f && Math.Abs(vertical)<0.01f)
        {
            _animator.SetFloat("Velocity", 0);    
        }
        else
        {
            _animator.SetFloat("Velocity", 0.15f );
        }
        
    }
    */ 
    //TODO: TRUCO , COLOCAR VELOCIDAD DE ANDAR Y OTRA PARA CORRER Y SOLO ES MULLTIPLICAR
    //TODO: PARA Q VAYA MAS RAPIDO AL PULSAR SHIFT Y ASI CORRE
    
    
/*
// Mov para adelante
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    {
        transform.Translate(0,0,space);    
    }
// Mov para detras
    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
    {
        transform.Translate(0,0,-space);    
    }
//Mov para Derecha
    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
        transform.Translate(space,0,0);    
    }
//Mov para Izquierda
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    {
        transform.Translate(-space,0,0);    
    }
*/

}


}
