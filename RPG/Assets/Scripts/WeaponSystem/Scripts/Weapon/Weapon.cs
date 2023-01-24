using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Animator weaponAnimation;

    public Animator WeaponAnimation => weaponAnimation;
    public abstract void Attack(LayerMask enemy);

    //[SerializeField] protected WeaponData weaponData; // Удалено, чтобы в Sword можно было ставить только SwordData, а в Bow только BowData.
    //public WeaponData WeaponData => weaponData;
}
