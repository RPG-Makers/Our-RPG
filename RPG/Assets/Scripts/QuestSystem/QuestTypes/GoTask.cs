using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTask : Task
{
    private PlaceForTask _place;

    public GoTask(string name, string description, PlaceForTask place) : base(name, description)
    {
        _place = place;
        _place.PlayerSpotted += TaskCompleted;
    }

    protected override void TaskCompleted()
    {
        _place.PlayerSpotted -= TaskCompleted;
        base.TaskCompleted();
    }
}
