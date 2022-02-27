using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [Tooltip("Tiempo despues del cual se destruye el objeto")]
    public float destructionDeLay;
    
    private void OnEnable()
    {
        //Destroy(gameObject, destructionDeLay);
        Invoke("HideObject", destructionDeLay);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }
}
