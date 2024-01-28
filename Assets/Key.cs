using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.root.gameObject.CompareTag("Player"))
        {
            MissionCompletion.Instance.updateKeysCollected();
            Destroy();

        }

    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
