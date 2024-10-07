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

    //parameters
    [SerializeField] float angerDist = 5f;
    [SerializeField] float stoppingDist = 15f;
    [SerializeField] float rotationSpeed = 2f;

    //states
    bool isAggro = false;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(target.position, transform.position);
        if (distToPlayer <= angerDist) isAggro = true;

        if (isAggro)
        {
            RotateToFacePlayer();
            DefineAggroState(distToPlayer);
        }


    }

    void DefineAggroState(float distToPlayer)
    {
        if (distToPlayer < navAgent.stoppingDistance) AttackTarget();
        else ChaseTarget();

        if (distToPlayer >= stoppingDist) isAggro = false;
    }

    void ChaseTarget()
    {
        if (isAggro) navAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        Debug.Log("attacking player");
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
}
