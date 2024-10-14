using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHealth = 100f;

    public void TakeDamage(float damageDealt)
    {
        enemyHealth -= damageDealt;
        Debug.Log(enemyHealth);

        if (enemyHealth <= 0) KillEnemy();

        BecomeAggro();
    }

    void BecomeAggro()
    {
        GetComponent<EnemyAI>().OnDamageTaken();
    }

    void KillEnemy()
    {
        Destroy(gameObject);
    }
}
