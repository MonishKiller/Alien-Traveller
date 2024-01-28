using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SPSFManager SPSFManager;
    public int maxhealth = 100;
    public int currentHealth;
    public HealthBar heathBar;

    [SerializeField] private GameObject takeDamageVFx;
    [SerializeField] private GameObject destroyEffect;

    void Start()
    {
        currentHealth = maxhealth;
        heathBar.SetMaxHealth(maxhealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        heathBar.SetHealth(currentHealth);
        Instantiate(destroyEffect, this.transform.position, quaternion.identity);
        if (currentHealth <= 0)
        {
            SPSFManager.losePanel.ShowPanel();
            Destroy(this.gameObject);
        }
    }
    public void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }


}
