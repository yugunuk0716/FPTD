﻿using System;
using UnityEngine;
using System.Collections;

namespace FORGE3D
{
    public class F3DPlayerTurretController : MonoBehaviour
    {
        RaycastHit hitInfo; // Raycast structure
        public F3DTurret turret;
        bool isFiring; // Is turret currently in firing state
        public F3DFXController fxController;

        void Update()
        {
            CheckForFire();
        }

        private void LateUpdate()
        {
            CheckForTurn();
        }

        void CheckForFire()
        {
            // Fire turret
            if (!isFiring && Input.GetMouseButtonDown(0))
            {
                isFiring = true;
                fxController.Fire();
            }

            // Stop firing
            if (isFiring && Input.GetMouseButtonUp(0))
            {
                isFiring = false;
                fxController.Stop();
            }

            
        }

        void CheckForTurn()
        {
            // Construct a ray pointing from screen mouse position into world space
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Raycast
            if (Physics.Raycast(cameraRay, out hitInfo, 500f))
            {
                turret.SetNewTarget(hitInfo.point);
            }
        }
    }
}