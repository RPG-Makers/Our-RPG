using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyRangeBase : EnemyBase
{
    private BowData BowData { get; set; }
    private int _distanceBow; // Дальность атаки лука. В будущем перенести в скрипт лука. // Также в базовом классе есть _attackingDistance.

    private void Update()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(this.transform.position, _target.transform.position);
            if (distance <= _enemyData.RunAwayDistance)
            {
                RunAway(); // Or take sword and attack.
            }
            else if (distance <= _distanceBow)
            {
                if (_delayAttack <= 0)
                {
                    RangeAttack();
                }
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _enemyData.Speed);
            }
        }
    }

    private void RangeAttack()
    {
        _delayAttack = _weaponData.Cooldown;
        _isAttacking = true;
        Debug.Log("Enemy is range attacking.");
    }
}
