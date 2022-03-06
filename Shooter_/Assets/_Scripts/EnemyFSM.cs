using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private Animator animator;
    
    private float lastShootTime;
    public float shootRate;

    public GameObject shootingPoint;
    
    private void Awake()
    {
        _vista = GetComponent<Vista>();
        baseTransform = GameObject.Find("Base").transform;
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
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
        animator.SetBool("Shoot Bullet Bool", false);
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
        LookAt(baseTransform.position);
        ShootTarget();
    }

    void ChasePlayer()
    {
        animator.SetBool("Shoot Bullet Bool", false);
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
        LookAt(_vista.detectedTarget.transform.position);
        ShootTarget();


        float distanceToPlayer = Vector3.Distance(transform.position, _vista.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance*1.1f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    
    void ShootTarget()
    {
        if (Time.timeScale>0)
        {
            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < shootRate)
            {
                return;
            }
            animator.SetBool("Shoot Bullet Bool", true);
            
            lastShootTime = Time.time;
            var bala = ObjectPool.SharedInstance.GetFirstPooledObject();
            bala.layer = LayerMask.NameToLayer("Bala Enemigo");
            bala.transform.position = shootingPoint.transform.position;
            bala.transform.rotation = shootingPoint.transform.rotation;
            bala.SetActive(true);
        }

        
    }

    void LookAt(Vector3 targetPos)
    {
        Vector3 directionToLook = Vector3.Normalize(targetPos- transform.position);
        directionToLook.y = 0;
        transform.parent.forward = directionToLook;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }

    
}
