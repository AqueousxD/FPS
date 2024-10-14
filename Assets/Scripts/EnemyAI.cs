using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //references
    [SerializeField] Transform target;
    NavMeshAgent navAgent;
    Animator anim;

    //parameters
    [SerializeField] float angerDist = 5f;
    [SerializeField] float stoppingDist = 15f;
    [SerializeField] float rotationSpeed = 2f;

    //states
    bool isAggro = false;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(target.position, transform.position);
        if (distToPlayer <= angerDist && distToPlayer >= navAgent.stoppingDistance)
        {
            isAggro = true;
            Debug.Log("is aggro");
        }

        if (isAggro)
        {
            RotateToFacePlayer();
            DefineAggroState(distToPlayer);
            anim.SetTrigger("isMoving");
            
        }


    }

    void DefineAggroState(float distToPlayer)
    {
        if (distToPlayer < navAgent.stoppingDistance) AttackTarget();
        else ChaseTarget();

        if (distToPlayer >= stoppingDist)
        {
            isAggro = false;
            anim.SetTrigger("isIdle");
            Debug.Log("is idling");
        }
    }

        void ChaseTarget()
        {
            if (isAggro) navAgent.SetDestination(target.position);
        }

        void AttackTarget()
        {
            isAggro = false;
            Debug.Log("attacking player");
            anim.SetTrigger("isAttacking");
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, angerDist);
            Gizmos.DrawWireSphere(transform.position, stoppingDist);
        }

        void RotateToFacePlayer()
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion currentRotation = transform.rotation;
            Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            transform.rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * rotationSpeed);
        }

        public void OnDamageTaken()
        {
            isAggro = true;
        } 

}
