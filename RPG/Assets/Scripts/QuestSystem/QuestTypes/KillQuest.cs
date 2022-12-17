using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class KillTask : Task
{
    private Type _typeOfEnemy;
    private int _currentAmount;
    private int _requiredAmount;

    public KillTask(string name, string description, Type typeOfEnemy, int amount) : base(name, description)
    {
        _typeOfEnemy = typeOfEnemy;
        _currentAmount = 0;
        _requiredAmount = amount;
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
