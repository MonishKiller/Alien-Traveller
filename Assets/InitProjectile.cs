using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitProjectile : MonoBehaviour
{
    [SerializeField] private PortalProjectile portalProjectile;
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        string layerName = LayerMask.LayerToName(col.transform.gameObject.layer);
        if (layerName == "Ground")
        {
            ContactPoint2D contact = col.contacts[0]; // Get the first contact point
            Vector2 collisionPoint = contact.point;
            portalProjectile.CreatePortal(collisionPoint);
            this.gameObject.SetActive(false);
        }


    }
}
