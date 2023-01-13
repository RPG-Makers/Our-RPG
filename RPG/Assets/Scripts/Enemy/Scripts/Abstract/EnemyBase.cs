using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class, that represents Enemy base class.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public abstract class EnemyBase : MonoBehaviour
{
    protected EnemyData _enemyData;
    protected WeaponData _weaponData;
    //protected abstract void Attack();
    //protected abstract void DropLoot(); // Probably don't need. Because the death are in the Health script.
}
