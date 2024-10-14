using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUtility : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitVHX;

    [SerializeField] float raycastRange;
    [SerializeField] float damage = 10f;

    Vector3 raycastHitPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Shoot()
    {
        ProcessRaycast();
        PlayMuzzleFlash();
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
            if(enemyTarget != null) enemyTarget.TakeDamage(damage);
        }
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
}
