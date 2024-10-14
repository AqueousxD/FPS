using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth playerTarget;

    [SerializeField] float damage = 50f;

    public void AttackHitEvent()
    {
        if (playerTarget == null) return;

        playerTarget.TakeDamage(damage);
    }
}
