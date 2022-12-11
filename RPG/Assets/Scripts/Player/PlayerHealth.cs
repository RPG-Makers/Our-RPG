using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private int maxHealth = 100;

    public HealthBar HealthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    public void UpdateHealth(int mod)
    {
        currentHealth += mod;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        } else if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player Respawn");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            getDamage(1);
        }
    }

    public void getDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }
}