using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skeleton))]
public class SkeletonHealth : EnemyHealth
{
    public static Action Died;
    protected override void Death()
    {
        Died.Invoke();
        Debug.Log("Skeleton did something after death.");
    }
}
