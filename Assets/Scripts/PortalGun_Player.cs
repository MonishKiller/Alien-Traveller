using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun_Player : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    Vector2 direction;
    [SerializeField] private float force;
    [SerializeField] private Transform firePoint;


    [Header("Trajectory Path")]
    public GameObject pointPrefab;
    public GameObject[] points;
    public int numberOfpoints;

    [SerializeField] private Transform trajectoryParent;

    public bool TrajectoryVisible { get; private set; }


    [Header("Prefabs Portal")]
    [SerializeField] private GameObject[] projectilesPrefabs;
    [SerializeField] private GameObject[] activePortal;



    private void Start()
    {
        InitializeTrajectoryPoints();
        ShowTrajactoryPoints(false);
    }
    public void Fire(GameEnum.PortalEnum currentProjectile)
    {
        activePortal[(int)currentProjectile] = Instantiate(projectilesPrefabs[(int)currentProjectile], firePoint.position, Quaternion.identity);
        if (playerController.IsFacingRight)
            activePortal[(int)currentProjectile].transform.GetComponentInChildren<Rigidbody2D>().velocity = transform.right * force;
        else
            activePortal[(int)currentProjectile].transform.GetComponentInChildren<Rigidbody2D>().velocity = transform.right * force * -1;
    }
    public void InitializeTrajectoryPoints()
    {
        points = new GameObject[numberOfpoints];
        for (int i = 0; i < numberOfpoints; i++)
        {
            points[i] = Instantiate(pointPrefab, transform.position, Quaternion.identity);
            points[i].transform.SetParent(trajectoryParent);
        }
    }
    public void TelportToNext_ActivePortal(GameEnum.PortalEnum _portalType)
    {
        if (_portalType == GameEnum.PortalEnum.Blue)
        {
            if (activePortal[(int)GameEnum.PortalEnum.Red] != null)
            {
                Debug.Log("Teleport : 2");
                playerController.gameObject.transform.position = activePortal[(int)GameEnum.PortalEnum.Red].transform.position;
            }

        }
        else if (_portalType == GameEnum.PortalEnum.Red)
        {
            if (activePortal[(int)GameEnum.PortalEnum.Blue] != null)
            {
                playerController.gameObject.transform.position = activePortal[(int)GameEnum.PortalEnum.Blue].transform.position;
            }
        }


    }
    public void ShowTrajactory()
    {
        Vector2 MousPOs = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 portalGunPos = transform.position;
        direction = MousPOs - portalGunPos;
        FaceMouse();
        for (int i = 0; i < points.Length; i++)
        {
            points[i].transform.position = pointPosition(i * 0.1f);
        }

    }
    public void ShowTrajactoryPoints(bool isActive)
    {
        trajectoryParent.gameObject.SetActive(isActive);
        TrajectoryVisible = isActive;
    }

    private void FaceMouse()
    {
        if (playerController.IsFacingRight)
        {

            transform.right = direction * 1;
        }
        else
        {
            transform.right = direction * -1;
        }

    }
    Vector2 pointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (direction.normalized * force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }

}
