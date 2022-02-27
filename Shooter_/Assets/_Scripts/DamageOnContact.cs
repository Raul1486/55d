using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log(other.name);
       //Destroy(gameObject); PROHIBIDO, OBJECT POOLING ES MEJOR
       gameObject.SetActive(false);// DESACTIVA LA BALA Y LA REGENERA EN LA PISCINA DE BALAS
       
       /*if (other.CompareTag("Enemigo") || other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            } */
        //ESTO DESTRUYE AL JUG/ENEM QUE LE DA LA BALA GRACIAS A LAS ETIQUETAS


        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            life.Amount -= damage; // life.amount = life.amount - damage
        }

    }
}
