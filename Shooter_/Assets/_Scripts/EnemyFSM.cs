using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Vista))]
public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;
    private Vista _vista;

    private Transform baseTransform;
    public float baseAttackDistance, playerAttackDistance;

    private NavMeshAgent agent;
    
    
    private void Awake()
    {
        _vista = GetComponent<Vista>();
        baseTransform = GameObject.Find("Base").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    private void Update()
    {
        switch (currentState) //esto se usa cuando hay muchos IF sobre una misma variante
        {
            case EnemyState.GoToBase:
            GoToBase();
                break;
            
            case EnemyState.AttackBase:
                AttackBase();
                break;
            
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
            
            default:
                //TODO: caso por defecto
                break;
        }
        
    }
    
    /*  //esto se sustituye por SWITCH
        if (currentState == EnemyState.GoToBase)
        {
            //
                    }
        if (currentState == EnemyState.AttackBase)
        {
            //
        }
        if (currentState==EnemyState.ChasePlayer)
        {
            //
        }
        if (currentState==EnemyState.AttackPlayer)
        {
            //
        }*/

    void GoToBase()
    {
        print("Ir a base");

        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        
        if (_vista.detectedTarget != null)
        {
            currentState = EnemyState.ChasePlayer;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase() // ESTE SE QUEDA VACIO XQ SI LLEGAN A LA BASE VA QUEDARSE AHI HASTA QUE MUERA...
    {
        agent.isStopped = true;
        print("atacar base");
    }

    void ChasePlayer()
    {
        print("persigue jug");
        if (_vista.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(_vista.detectedTarget.transform.position);
        
        float distanceToPlayer = Vector3.Distance(transform.position,_vista.detectedTarget.transform.position);
        if (distanceToPlayer < playerAttackDistance);
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackPlayer()
    {
        print("ataca jug");

        agent.isStopped = true;
        
        if (_vista.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }


        float distanceToPlayer = Vector3.Distance(transform.position, _vista.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance*1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    
}
