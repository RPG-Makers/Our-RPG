using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ISkeleton))]
public class SkeletonHealth : EnemyHealth
{
    protected override void Death()
    {
        base.Death();
        Debug.Log("Skeleton did something after death.");
    }
}
