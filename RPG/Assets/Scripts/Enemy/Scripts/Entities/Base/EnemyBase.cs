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
    protected EnemyData _enemyData;
    protected WeaponData _weaponData;

    protected bool _isAttacking;

    protected GameObject _target;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().edgeRadius = _enemyData.DetectionDistance;
        Debug.Log("Edge radius changed");
    }

    private void Update()
    {
        //_weaponData.Cooldown -= Time.deltaTime; // �������� ������� ������. �������� ��� ����� ����������� ���������� �����������.
    }

    protected void RunAway() // Not completed.
    {
        _isAttacking = false;
        // ����� ��������� ������� �� ������ ���� ����� �� ����������� �������� ������, � ������� �����-�� ��������� ����� ����� � ����� � ��� (��������, � ����������� ���������).
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

    //protected abstract void Attack(); // Instead of MeeleAttack() and RangeAttack().

    //protected abstract void DropLoot(); // Probably don't need. Because the death are in the Health script.
    //protected override void DropLoot() // or Death() or somethings like this..... // Already have death in SkeletonHealth.cs!
    //{
    //    Debug.Log("Skeleton droped some loot after death.");
    //}
    //private void Update() // ��� ������������� � ����������� ����� �������������� Update() (override or new) ��� �������� ���������� ������ ��� �����.
    //{
    //    Debug.Log("Skeleton is doing something interesting");
    //}
}
