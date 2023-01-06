using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkeletonHealth))]
public class Skeleton : Enemy
{
    protected override void Attack()
    {
        Debug.Log("Skeleton is attacking.");
    }

    //protected override void DropLoot() // or Death() or somethings like this..... // Already have death in SkeletonHealth.cs!
    //{
    //    Debug.Log("Skeleton droped some loot after death.");
    //}
}
