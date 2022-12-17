using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoQuest : Quest
{
    private PlaceForQuest _place;

    public GoQuest(string name, string description, PlaceForQuest place) : base(name, description)
    {
        _place = place;
        _place.PlayerSpotted += QuestCompleted;
    }

    private void QuestCompleted()
    {
        _place.PlayerSpotted -= QuestCompleted;
        Debug.Log($"Quest {this.Name} done");
        // player.CloseQuest(this);
    }
}
