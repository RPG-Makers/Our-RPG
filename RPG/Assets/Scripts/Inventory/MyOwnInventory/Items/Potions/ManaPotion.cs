using System;
using UnityEngine;

public class ManaPotion : Item
{
    [SerializeField] private int _restoreAmount;
    public static Action OnManaPotionDrunk; // ������ ��������� �� ��� ������� � � ����������� ������ ������������ ����.

    public override void Use()
    {
        OnManaPotionDrunk.Invoke();
        Debug.Log("Mana Potion Drunk");
    }
}
