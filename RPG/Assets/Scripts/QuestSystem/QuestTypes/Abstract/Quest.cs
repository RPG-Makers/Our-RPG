using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Quest(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
