using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 100f;

    public void TakeDamage(float damageTaken)
    {
        playerHealth -= damageTaken;
        Debug.Log("Health is now " + playerHealth + " hp");

        if (playerHealth <= 0) Debug.Log("you are dead");
    }
}
