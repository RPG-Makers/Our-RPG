using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
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
