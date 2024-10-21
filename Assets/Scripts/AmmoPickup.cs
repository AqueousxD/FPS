using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] Ammo ammo;
    [SerializeField] int ammoAmountInPickup = 10;
    [SerializeField] AmmoType ammoTypeInPickup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ammo.IncreaseAmmo(ammoTypeInPickup, ammoAmountInPickup);
            Destroy(gameObject);
        }
    }
}
