using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Animator weaponAnimation;

    public Animator WeaponAnimation => weaponAnimation;
    public abstract void Attack(LayerMask enemy);

    //[SerializeField] protected WeaponData weaponData; // �������, ����� � Sword ����� ���� ������� ������ SwordData, � � Bow ������ BowData.
    //public WeaponData WeaponData => weaponData;
}
