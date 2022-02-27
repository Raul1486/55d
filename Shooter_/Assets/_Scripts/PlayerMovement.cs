using System;
using System.Collections;
using System.Collections.Generic;
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


    private Rigidbody rb;
    
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        rb = GetComponent<Rigidbody>(); //ESTO ES SIEMPRE EN EL START
        
    }

    void Update()
{
    float space = speed * Time.deltaTime;
    float horizontal = Input.GetAxis("Horizontal"); // -1 a 1
    float vertical = Input.GetAxis("Vertical"); // -1 a 1

    Vector3 dir = new Vector3(horizontal, 0, vertical);
    //transform.Translate(dir.normalized * space);
    // SUSTITUIR X FUERZA DE TRASLACION
    rb.AddRelativeForce(dir.normalized * space);
    
    float angle = rotationSpeed * Time.deltaTime;
    float mouseX = Input.GetAxis("Mouse X"); // -1 a 1
    //float mouseY = Input.GetAxis("Mouse Y"); // -1 a 1
    
    //transform.Rotate(0, mouseX * angle, 0);
    // SUSTITUIR X FUERZA ROTACION <-> TORQUE
    rb.AddRelativeTorque(0, mouseX * angle, 0);
    
    
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
