using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class KillQuest : Quest
{
    private Type _typeOfEnemy;
    private int _currentAmount;
    private int _requiredAmount;

    public KillQuest(string name, string description, Type typeOfEnemy, int amount) : base(name, description)
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
            QuestCompleted();
        }
    }

    protected override void QuestCompleted()
    {
        base.QuestCompleted();
    }
}
