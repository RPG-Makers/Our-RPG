using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : QuestGiver
{
    protected override void GiveTask(GameObject player)
    {
        if (givedQuest) { return; }

        _task = new KillTask("Kill 10 skeletons", "Find them and kill!", typeof(Skeleton), 10);
        base.GiveTask(player);
    }
}
