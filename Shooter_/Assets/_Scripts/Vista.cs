using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista : MonoBehaviour
{
   public float distance;
   public float angle;

   public LayerMask targetLayers;
   public LayerMask obstacleLayers;

   public Collider detectedTarget;
   private Collider[] colliders;
   
   private void Update()
   {
      /*if (Physics.OverlapSphereNonAlloc(transform.position, distance, this.colliders,
             targetLayers) == 0)
      {
         return;
      }*/
      
      colliders = Physics.OverlapSphere(transform.position, distance, targetLayers);

      detectedTarget = null;
      //SI ESTAMOS AQUI ES QUE HEMOS PASADO EL PRIMER FILTRO, LA DISTANCIA.
      //SI NO NECESITO LA POSICION SE HACE ESTE: "FOREACH"
      foreach (Collider collider in colliders)
      {
         Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);
         // ANGULO QUE FORMAN EL VECTOR VISION CON EL VECTOR OBJETIVO
         float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);
         
         //SI EL ANGULO ES MENOR QUE EL DE VISION
         if (angleToCollider < angle)
         {  
            //COMPROBAMOS QUE EN LA LINEA DE VISION DIRECTA NO HAY OBSTACULOS
            if (!Physics.Linecast(transform.position, collider.bounds.center,
                   out RaycastHit hit, obstacleLayers))
            {
               Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
               //guardamos la referncia del obj detectado
               detectedTarget = collider;
               break;
            }
            else //HAY HIT
            {
               Debug.DrawLine(transform.position, hit.point, Color.red);
            }
         }
      }

     
      /* //SI NECESITO LA POSICION DEL COLLIDER SE HACE ESTE: "FOR"
      for (int i = 0; //INICIALIZACION
           i < colliders.Length;  //CONTINUACION
           i++) //ACTUALIZACION    
      {
         Collider collider = colliders[i];
         //TODO: HACER COSAS AL COLLIDER
      }*/
      
      
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.magenta;
      Gizmos.DrawWireSphere(transform.position, distance);
      
      Gizmos.color = Color.magenta;
      Vector3 rightDir = Quaternion.Euler(0, angle,0) * transform.forward;
      Gizmos.DrawRay(transform.position, rightDir*distance);

      Vector3 leftDir = Quaternion.Euler(0, -angle, 0) * transform.forward;
      Gizmos.DrawRay(transform.position, leftDir*distance);
   }
}
