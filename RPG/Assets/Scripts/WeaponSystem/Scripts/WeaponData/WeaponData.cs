using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    public string Name;
    public int Damage;
    public float Reloading;
    public int Durability;
    public int DefaultPrice;
    //[SerializeField] public weaponType Type;
    //public enum weaponType
    //{
    //    Sword,
    //    Bow
    //}
}
