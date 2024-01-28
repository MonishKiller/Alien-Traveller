using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private PortalGun_Player portalGun;
    [SerializeField] private PlayerHealth playerHealth;

    private bool _portalGunActive = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TogglePortalGun();
        }
        PortalGunSystem();
        PortalGunShootSystem();

        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyAllPortals();
        }

    }
    public void Teleport(GameEnum.PortalEnum _currentPortal)
    {
        Debug.Log("Teleport : 1");
        portalGun.TelportToNext_ActivePortal(_currentPortal);

    }
    private void PortalGunShootSystem()
    {
        if (_portalGunActive && Input.GetMouseButtonDown(0))
        {
            portalGun.Fire(GameEnum.PortalEnum.Blue);
        }
        if (_portalGunActive && Input.GetMouseButtonDown(1))
        {
            portalGun.Fire(GameEnum.PortalEnum.Red);
        }

    }
    private void PortalGunSystem()
    {
        if (_portalGunActive)
        {
            if (portalGun.TrajectoryVisible == false)
                portalGun.ShowTrajactoryPoints(true);
            portalGun.ShowTrajactory();
        }
        else
        {
            if (portalGun.TrajectoryVisible == true)
                portalGun.ShowTrajactoryPoints(false);
        }
    }
    private void TogglePortalGun()
    {
        if (_portalGunActive == false)
        {
            _portalGunActive = true;
            portalGun.gameObject.SetActive(true);
        }
        else
        {
            _portalGunActive = false;
            portalGun.gameObject.SetActive(false);
        }

    }
    private void DestroyAllPortals()
    {
        PortalProjectile[] portalsList = FindObjectsOfType<PortalProjectile>();
        foreach (PortalProjectile _portalProjectile in portalsList)
        {
            _portalProjectile.Destroy();
        }
        if (portalsList.Length > 0)
        {
            playerHealth.TakeDamage(20);
        }

    }
}
