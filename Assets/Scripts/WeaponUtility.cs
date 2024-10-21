using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponUtility : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVHX;
    [SerializeField] Ammo ammo;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TMP_Text ammoUIText;

    [SerializeField] float raycastRange;
    [SerializeField] float damage = 10f;
    [SerializeField] float weaponCooldown = 0.15f;

    public bool canShoot = true;
    Vector3 raycastHitPos;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot) StartCoroutine(Shoot());
        UpdateAmmoUI();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammo.GetAmmoAmount(ammoType) > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammo.ReduceAmmo(ammoType);
            
        }
        yield return new WaitForSeconds(weaponCooldown);
        canShoot = true;
    }
    
    void ProcessRaycast()
    {
        RaycastHit hitInfo;
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red, 2);

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo, raycastRange))
        {
            raycastHitPos = hitInfo.point;
            CreateHitEffect(hitInfo);
            EnemyHealth enemyTarget = hitInfo.transform.GetComponent<EnemyHealth>();
            if (enemyTarget != null) enemyTarget.TakeDamage(damage);
        }
        else return;
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void CreateHitEffect(RaycastHit hitInfo)
    {
        GameObject impact = Instantiate(hitVHX, raycastHitPos, Quaternion.identity);
        Destroy(impact, 0.1f);
    }

    void UpdateAmmoUI()
    {
        ammoUIText.text = ammo.GetAmmoAmount(ammoType) + "/" + ammo.GetMaxAmmoAmount(ammoType);
    }
}
