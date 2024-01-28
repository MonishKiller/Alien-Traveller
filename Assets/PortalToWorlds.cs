using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalToWorlds : MonoBehaviour
{
    [SerializeField] private Transform targetPosition;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetPosition != null && other.gameObject.transform.root.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.transform.root.gameObject;
            player.transform.position = targetPosition.position;
        }

    }
}
