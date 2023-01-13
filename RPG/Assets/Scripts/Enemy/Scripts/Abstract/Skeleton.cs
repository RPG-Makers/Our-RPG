using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkeletonHealth))]
public abstract class Skeleton : EnemyBase
{
    private void Update() // ѕри необходимости в наследниках можно переопределить Update() (override or new) дл€ созданий уникальной логики дл€ врага.
    {
        Debug.Log("Skeleton is doing something interesting");
    }
}