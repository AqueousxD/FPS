using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //references
    [SerializeField] Transform Target;
    NavMeshAgent navAgent;

    //parameters
    [SerializeField] float angerDist = 5f;
    [SerializeField] float stoppingDist = 15f;
    bool isChasing = false;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(Target.position, transform.position);
        if (distToPlayer <= angerDist) isChasing = true;

        if (distToPlayer >= stoppingDist) isChasing = false;

        if (isChasing) navAgent.SetDestination(Target.position);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, angerDist);
        Gizmos.DrawWireSphere(transform.position, stoppingDist);
    }
}
