using System;
using UnityEngine;

public class HealthPotion : Item
{
    [SerializeField] private int _restoreAmount;
    public static Action OnHealthPotionDrunk; // Игрока подписать на это событие и в подписанном методе восстановить здоровье.

    public override void Use()
    {
        OnHealthPotionDrunk.Invoke();
        Debug.Log("Health Potion Drunk");
    }
}
