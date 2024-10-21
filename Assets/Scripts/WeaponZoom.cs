using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCam;

    float zoomInValue = 42.5f;
    float zoomOutValue = 60f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerCam.fieldOfView = zoomInValue;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            playerCam.fieldOfView = zoomOutValue;
        }
    }
}
