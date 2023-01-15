using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

/// <summary>
/// Class, that represents Enemy base class.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
[RequireComponent (typeof(EnemyHealth))]
public abstract class EnemyBase : MonoBehaviour
{
    private EnemyData _enemyData;
    private WeaponData _weaponData;

    private float _detectionDistance; // ƒальность обнаружени€ игрока. »спользуетс€ только дл€ инициализации радиуса коллайдера. ƒальше отрабатывает OnCollisionEnter/Exit.
    protected float _runAwayDistance;

    private bool _isAttacking;

    protected GameObject _target;

    protected float _someSpeed;


    private void Awake()
    {
        GetComponent<BoxCollider2D>().edgeRadius = _detectionDistance;
        Debug.Log("Edge radius changed");
    }

    protected void RunAway() // Not completed.
    {
        // Ѕудет прикольно сделать не просто уход назад по направлению толкани€ игрока, а выбрать какую-то рандомную точку сзади и пойти к ней (возможно, с увеличенной скоростью).
        Debug.Log("Enemy is running away.");
        //return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected");
            _target = collision.gameObject;
            _isAttacking = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player out");
            _target = null;
            _isAttacking = false;
        }
    }





    //protected abstract void DropLoot(); // Probably don't need. Because the death are in the Health script.
    //protected override void DropLoot() // or Death() or somethings like this..... // Already have death in SkeletonHealth.cs!
    //{
    //    Debug.Log("Skeleton droped some loot after death.");
    //}
    //private void Update() // ѕри необходимости в наследниках можно переопределить Update() (override or new) дл€ созданий уникальной логики дл€ врага.
    //{
    //    Debug.Log("Skeleton is doing something interesting");
    //}
}
