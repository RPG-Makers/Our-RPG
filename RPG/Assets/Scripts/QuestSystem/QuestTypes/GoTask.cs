using System;
using UnityEngine;

[Serializable]
public class GoTask : Task
{
    [SerializeField] private PlaceForTask _place;

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
