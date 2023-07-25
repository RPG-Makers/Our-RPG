using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _currentHealth = 0;
    [SerializeField] private int _maxHealth = 100;

    public HealthBar HealthBar;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        HealthBar.SetMaxHealth(_maxHealth);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            GetDamage(1);
        }
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;

        if (_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        //else if (currentHealth <= 0)
        //{
        //    currentHealth = 0;
        //    Debug.Log("Player Respawn");
        //}
        HealthBar.SetHealth(_currentHealth);
    }

    public void GetDamage(int damage)
    {
        _currentHealth -= damage;
        HealthBar.SetHealth(_currentHealth);
        if (_currentHealth <= 0) Death();
    }

    private void Death()
    {
        Debug.Log("Player died.");
    }
}