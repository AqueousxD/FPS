using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    WeaponUtility currWeaponUtility;
    int weaponNum;

    private void Start()
    {
        weaponNum = transform.childCount;
        currWeaponUtility = GetComponentInChildren<WeaponUtility>(false);
    }

    private void Update()
    {
        ProcessScrollWheel();
        SetWeaponActive();
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
                currWeaponUtility = weapon.gameObject.GetComponent<WeaponUtility>();
            }
            else if (weaponIndex != currentWeapon) weapon.gameObject.SetActive(false);
            weaponIndex++;
            
        }
    }

    public void ProcessScrollWheel()
    {
        if (currWeaponUtility.canShoot == false) return;
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            currentWeapon++;
            currentWeapon = currentWeapon % weaponNum;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            currentWeapon--;
            if (currentWeapon < 0) currentWeapon = (weaponNum - 1);
            currentWeapon = currentWeapon % weaponNum;
        }
    }
}
