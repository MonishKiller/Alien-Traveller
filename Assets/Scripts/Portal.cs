using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public GameEnum.PortalEnum portalType;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && portalType == GameEnum.PortalEnum.Blue)
        {
            Debug.Log("Gameplay :Player Enterd the Portal");
            col.gameObject.transform.root.gameObject.GetComponent<PlayerWeapon>().Teleport(portalType);
            DestroyObjectfromRoot();
        }
    }

    private void DestroyObjectfromRoot()
    {
        Destroy(this.gameObject.transform.root.gameObject, 0.1f);
    }

}
