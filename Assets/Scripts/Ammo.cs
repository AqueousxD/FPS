using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
        public int maxAmmoAmount;
    }

    public int GetAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public int GetMaxAmmoAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).maxAmmoAmount;
    }

    public void ReduceAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseAmmo(AmmoType ammoTypeFromPickup, int ammoAmountFromPickup)
    {
        GetAmmoSlot(ammoTypeFromPickup).ammoAmount = GetAmmoSlot(ammoTypeFromPickup).ammoAmount + ammoAmountFromPickup;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach(AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType) return slot;
        }
        return null;
    }
}
