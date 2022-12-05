using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeWeapon", menuName = "Create new weapon")]
public class WeaponStats : ScriptableObject
{
    [SerializeField] private new string name;
    [SerializeField] public int damage;
    [SerializeField] private float reloading;
    [SerializeField] private int durability;
    [SerializeField] private int defaultPrice;
    [SerializeField] private weaponType type;
    private enum weaponType
    {
        Sword,
        Bow
    }
}
