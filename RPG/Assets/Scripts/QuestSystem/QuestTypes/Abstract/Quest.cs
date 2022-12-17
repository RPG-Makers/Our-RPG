using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool Completed { get; protected set; }

    public Quest(string name, string description)
    {
        Name = name;
        Description = description;
    }

    protected virtual void QuestCompleted()
    {
        Debug.Log($"Quest {Name} done");
        Completed = true;
        // player.CloseQuest(this);
    }
}
