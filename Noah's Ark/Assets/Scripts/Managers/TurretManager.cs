using FORGE3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoSingleton<TurretManager>
{
    public List<F3DTurret> turrets;


    private int currentTurretIndex = 0;

    [HideInInspector]
    public Camera mainCam;


    private void Awake()
    {
        turrets = new List<F3DTurret>();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        NextTurret();
    }


    public void AddTurret(F3DTurret turret)
    {
        turrets.Add(turret);
        print(turrets.Count);
        print(currentTurretIndex);

      
    }

    public void NextTurret()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            turrets[currentTurretIndex].isPlayer = false;
            turrets[currentTurretIndex].crosshair.SetActive(false);
            turrets[currentTurretIndex].shooter.fxController.Stop();
            currentTurretIndex++;
            if (turrets.Count <= currentTurretIndex)
            {
                currentTurretIndex = 0;
            }
            mainCam.transform.SetParent(turrets[currentTurretIndex].camTrm);
            mainCam.transform.localPosition = Vector3.zero;
            mainCam.transform.localRotation = Quaternion.identity;
            turrets[currentTurretIndex].isPlayer = true;
            turrets[currentTurretIndex].crosshair.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            turrets[currentTurretIndex].isPlayer = false;
            turrets[currentTurretIndex].crosshair.SetActive(false);
            turrets[currentTurretIndex].shooter.fxController.Stop();
            currentTurretIndex--;
            if (0 > currentTurretIndex)
            {
                currentTurretIndex = turrets.Count - 1;
            }
            mainCam.transform.SetParent(turrets[currentTurretIndex].camTrm);
            mainCam.transform.localPosition = Vector3.zero;
            mainCam.transform.localRotation = Quaternion.identity;
            turrets[currentTurretIndex].isPlayer = true;
            turrets[currentTurretIndex].crosshair.SetActive(true);
        }

    }

    public F3DTurret GetCurrentTurret()
    {
        if (turrets.Count == 0)
        {
            return null;
        }
        return turrets[currentTurretIndex];
    }


    public bool IsPlayer()
    {
        if (turrets == null) return false;

        if(turrets.Count > 0)
        {
            foreach (var turret in turrets)
            {
                if (turret == null) continue;
                if (turret.isPlayer)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
