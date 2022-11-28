using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSword : Weapon
{
    public override void Attack(LayerMask enemyLayer)
    {
        Debug.Log("Sword Attack");
        weaponAnimation.Play("smth");
        // this string should be in the weapon.Attack(), because there is different logic for sword and bow (UPD: Already ok. Just saving for... idk).
        Physics2D.OverlapCircle(transform.position, 1f, enemyLayer)?.gameObject.GetComponent<Health>().getHit(WeaponData.Damage); // I'm really don't understanding, why it doesn't work if we are using same Vector2.
    }
}
