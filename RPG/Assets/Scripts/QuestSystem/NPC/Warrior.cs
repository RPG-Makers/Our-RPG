using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : QuestGiver
{
    protected override void GiveQuest(GameObject player)
    {
        //if (givedQuest) { return; }

        //Task[] tasks = new Task[2] {
            //new KillTask("Kill 10 skeletons", "Find them and kill!", nameof(Skeleton), 10),
            //new GoTask("Find Petya", "Talk with him", _placeManager.GetComponent<PlacesLinks>().Petya)
        //};

        //_quest = new Quest("Skeletons and Petya", "Kill skeletons and find Petya", tasks);
        //base.GiveQuest(player);
    }
}
