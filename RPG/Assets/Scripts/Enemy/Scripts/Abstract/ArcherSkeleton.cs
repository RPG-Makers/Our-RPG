using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSkeleton : Skeleton, IArcher, IMelee
{
    public BowData BowData { get; set; }
    public SwordData SwordData { get; set; }

    private int _distanceBow; // ƒальность атаки лука. ¬ будущем перенести в скрипт лука.

    private float _detectionDistance; // ƒальность обнаружени€ игрока. »спользуетс€ только дл€ инициализации радиуса коллайдера. ƒальше отрабатывает OnCollisionEnter/Exit.
    private float _runAwayDistance;

    private bool _isAttacking;
    private GameObject _target;
    private float _someSpeed;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().edgeRadius = _detectionDistance;
        Debug.Log("Edge radius changed");
    }

    private void Update()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(this.transform.position, _target.transform.position);
            if (distance <= _runAwayDistance)
            {
                if (this is IMelee)
                {
                    (this as IMelee).MeleeAttack();
                }
                else
                {
                    RunAway();
                }
                //RunAway(); // Or take sword and attack.
                // Ѕудет прикольно сделать не просто уход назад по направлению толкани€ игрока, а выбрать какую-то рандомную точку сзади и пойти к ней (возможно, с увеличенной скоростью).
            }
            else if (distance <= _distanceBow)
            {
                (this as IArcher).RangeAttack();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _someSpeed);
            }
        }
    }

    void IArcher.RangeAttack()
    {
        Debug.Log("Skeleton is range attacking.");
    }

    void IMelee.MeleeAttack()
    {
        Debug.Log("Skeleton is melee attacking.");
    }

    private void RunAway() // Not completed.
    {
        Debug.Log("Skeleton is running away.");
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
    //protected override void DropLoot() // or Death() or somethings like this..... // Already have death in SkeletonHealth.cs!
    //{
    //    Debug.Log("Skeleton droped some loot after death.");
    //}
}
