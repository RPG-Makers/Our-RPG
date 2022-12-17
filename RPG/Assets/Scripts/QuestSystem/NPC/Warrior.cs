using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : QuestGiver
{
    protected override void GiveQuest(GameObject player)
    {
        if (givedQuest) { return; }

        _quest = new KillQuest("Kill 10 skeletons", "Find them and kill!", typeof(Skeleton), 10);
        base.GiveQuest(player);
    }
}
