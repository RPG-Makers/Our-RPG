using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerPotion : MonoBehaviour
{
    private void OnEnable()
    {
        HealthPotion.Notify += RestoreHealth;
    }
    private void OnDisable()
    {
        HealthPotion.Notify -= RestoreHealth;
    }

    private void RestoreHealth(int amount)
    {
        GetComponent<PlayerHealth>().IncreaseHealth(amount);
    }

    //private void RestoreMana()
    //{

    //}

    //private void RestoreStamina()
    //{

    //}
}
