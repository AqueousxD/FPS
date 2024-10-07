using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUtility : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] float raycastRange;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Shoot();
    }

    void Shoot()
    {
        RaycastHit hitInfo;
        Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hitInfo, raycastRange);
        Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red, 2);

        Debug.Log(hitInfo.transform.name);
    }
}
