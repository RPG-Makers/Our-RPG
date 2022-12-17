using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Death()
    {
        playerStatistics.NumberOfKilledSkeletons++;
        Debug.Log("Enemy did something after death.");
    }
    private void OnMouseDown()
    {
        GetDamage(1);
    }
}
