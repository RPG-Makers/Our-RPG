using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBow : Weapon
{
    public override void Attack(LayerMask enemyLayer)
    {
        Debug.Log("Bow Attack");
    }
}
