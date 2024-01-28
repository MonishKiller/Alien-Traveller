using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PortalProjectile : MonoBehaviour
{
    [SerializeField] private GameObject[] portalPrefabs;
    [SerializeField] private GameEnum.PortalEnum portalType;
    [SerializeField] private Transform portalParent;
    [SerializeField] private Vector2 offset;
    [SerializeField] private Rigidbody2D rb;
    public void CreatePortal(Vector2 hitPoint)
    {
        hitPoint += offset;
        this.gameObject.transform.position = new Vector3(hitPoint.x, hitPoint.y, 1f);
        GameObject portalCurrent = Instantiate(portalPrefabs[(int)portalType], portalParent.transform.position, quaternion.identity);
        portalCurrent.GetComponent<Portal>().portalType = portalType;
        portalCurrent.transform.SetParent(portalParent);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
