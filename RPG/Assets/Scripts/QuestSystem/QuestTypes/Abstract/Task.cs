using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    //public bool Completed { get; protected set; }
    public Action Completed;

    public Task(string name, string description)
    {
        Name = name;
        Description = description;
    }

    protected virtual void TaskCompleted()
    {
        Debug.Log($"Task {Name} done");
        Completed.Invoke();
        // player.CloseQuest(this);
    }
}
