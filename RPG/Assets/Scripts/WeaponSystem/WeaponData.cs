using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SomeWeapon", menuName = "Create new weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] public string Name;
    [SerializeField] public int Damage;
    [SerializeField] public float Reloading;
    [SerializeField] public int Durability;
    [SerializeField] public int DefaultPrice;
    //[SerializeField] public weaponType Type;
    //public enum weaponType
    //{
    //    Sword,
    //    Bow
    //}
}
