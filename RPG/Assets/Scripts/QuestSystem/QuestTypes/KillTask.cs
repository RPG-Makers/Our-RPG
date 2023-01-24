using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class KillTask : Task
{
    private string _typeOfEnemy;
    private int _currentAmount;
    private int _requiredAmount;

    public KillTask(string name, string description, string typeOfEnemy, int amount) : base(name, description) // Probably not type, just nameOfEnemy.
    {
        _typeOfEnemy = typeOfEnemy;
        _currentAmount = 0;
        _requiredAmount = amount;
        switch (_typeOfEnemy)
        {
            case "Skeleton":
                //Debug.Log("Так. Где-то сдох скелетон.");
                SkeletonHealth.Died += IncreaseCurrentAmount;
                break;
            default:
                Debug.LogWarning("Uknown enemy type");
                break;
        }
    }

    public void IncreaseCurrentAmount()
    {
        _currentAmount++;
        if (_currentAmount >= _requiredAmount)
        {
            TaskCompleted();
        }
    }

    protected override void TaskCompleted()
    {
        base.TaskCompleted();
    }
}
