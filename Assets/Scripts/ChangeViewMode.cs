using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeViewMode : MonoBehaviour
{
    private RCC_Camera RCCcamera;

    void Start()
    {
        RCCcamera = GetComponent<RCC_Camera>();
        if (RCCcamera == null)
        {
            Debug.Log("1");
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (RCCcamera.cameraMode == RCC_Camera.CameraMode.TPS)
            {
                RCCcamera.ChangeCamera(RCC_Camera.CameraMode.WHEEL);
            }
            else
            {
                RCCcamera.ChangeCamera(RCC_Camera.CameraMode.TPS);
            }
        }
           
    }
}
