using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyRangeBase : EnemyBase
{
    private BowData BowData { get; set; }
    private int _distanceBow; // Дальность атаки лука. В будущем перенести в скрипт лука.

    private void Update()
    {
        if (_target != null)
        {
            float distance = Vector3.Distance(this.transform.position, _target.transform.position);
            if (distance <= _runAwayDistance)
            {
                RunAway(); // Or take sword and attack.
            }
            else if (distance <= _distanceBow)
            {
                RangeAttack();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _someSpeed);
            }
        }
    }

    private void RangeAttack()
    {
        Debug.Log("Enemy is range attacking.");
    }
}
