using System;
using UnityEngine;

public class HealthPotion : ItemBase
{
    [SerializeField] private int _restoreAmount;
    public delegate void OnDrunk(int amount);
    public static event OnDrunk Notify;

    public override void Use()
    {
        Notify.Invoke(_restoreAmount);
        Debug.Log("Health Potion Drunk");
    }
}
