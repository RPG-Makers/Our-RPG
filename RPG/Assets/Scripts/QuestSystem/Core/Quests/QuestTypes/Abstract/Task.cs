using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Task
{
    public string Name;
    public string Description;
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
