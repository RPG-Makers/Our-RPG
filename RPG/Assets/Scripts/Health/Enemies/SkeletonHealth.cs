using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHealth : EnemyHealth
{
    public static Action Dead;
    protected override void Death()
    {
        Dead.Invoke();
        Debug.Log("Skeleton did something after death.");
    }
}
