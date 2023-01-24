using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMeeleBase : EnemyBase
{
    private SwordData SwordData { get; set; }

    private void Update()
    {
        if (_target != null)
        {
            // Здесь проверить, если достаточно близко, то атаковать, иначе двигаться.
            if (Vector3.Distance(this.transform.position, _target.transform.position) <= _attackingDistance)
            {
                // здесь проверить задержку атаки.
                MeeleAttack();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _someSpeed);
            }
        }
    }

    private void MeeleAttack()
    {
        Debug.Log("Enemy is melee attacking.");
    }
}
