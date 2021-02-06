﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    private const float DEFAULT_FOV = 60f;
    private const float ZOOMED_FOV = 20f;
    private const float ZOOM_OUT_SENSITIVITY = 2f;
    private const float ZOOM_IN_SENSITIVITY = 0.5f;

    [SerializeField] private Camera _fpsCamera;
    [SerializeField] private RigidbodyFirstPersonController _fpsController;

    private bool _zoomedInToggle = false;

    private void Update()
    {
        this.ProcessWeaponZoom();
    }

    private void ProcessWeaponZoom()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            this.SetCameraFieldOfView();
        }
    }

    private void SetCameraFieldOfView()
    {
        if (this._zoomedInToggle)
        {
            this._fpsCamera.fieldOfView = DEFAULT_FOV;
            this._fpsController.mouseLook.XSensitivity = ZOOM_OUT_SENSITIVITY;
            this._fpsController.mouseLook.YSensitivity = ZOOM_OUT_SENSITIVITY;
            this._zoomedInToggle = false;
        }
        else
        {
            this._fpsCamera.fieldOfView = ZOOMED_FOV;
            this._fpsController.mouseLook.XSensitivity = ZOOM_IN_SENSITIVITY;
            this._fpsController.mouseLook.YSensitivity = ZOOM_IN_SENSITIVITY;
            this._zoomedInToggle = true;
        }
    }
}
