using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponData weaponData;
    [SerializeField] protected Animator weaponAnimation;
    [SerializeField] protected Transform spawnParent;

    public WeaponData WeaponData => weaponData;
    public Animator WeaponAnimation => weaponAnimation;
    public abstract void Attack(LayerMask enemy);
}
