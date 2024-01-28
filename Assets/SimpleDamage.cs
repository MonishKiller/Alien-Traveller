using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDamage : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float waitTime;

    private bool takeDamage = true;
    private GameObject player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //  player.GetComponent<PlayerHealth>().TakeDamage(_damage);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.root.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.transform.root.gameObject;
            if (takeDamage)
            {
                player.GetComponent<PlayerHealth>().TakeDamage(_damage);
                takeDamage = false;
                StartCoroutine(WaitTime());

            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        StopCoroutine(WaitTime());

    }

    private IEnumerator WaitTime()
    {
        Debug.Log("Coroutine started.");
        // Wait for 3 seconds
        yield return new WaitForSeconds(waitTime);
        takeDamage = true;


    }
}
