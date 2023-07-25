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
            if (Vector3.Distance(this.transform.position, _target.transform.position) <= _weaponData.Distance)
            {
                if (_delayAttack <= 0)
                {
                    MeeleAttack();
                }
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _enemyData.Speed);
            }
        }
    }

    private void MeeleAttack()
    {
        _delayAttack = _weaponData.Cooldown;
        _isAttacking = true;
        Debug.Log("Enemy is melee attacking.");
    }
}
