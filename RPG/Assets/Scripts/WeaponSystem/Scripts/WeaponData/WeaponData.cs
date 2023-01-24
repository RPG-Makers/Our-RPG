using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    public string Name;
    public int Damage;
    public float Cooldown; // Кулдаун сам по себе не должен меняться, должна быть еще одна переменная.
    public int Durability;
    public float Distance; // Distance of attacking.
    public int DefaultPrice;
}
