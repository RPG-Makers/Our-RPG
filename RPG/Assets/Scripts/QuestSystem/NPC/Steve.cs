using UnityEngine;

public class Steve : QuestGiver
{
    protected override void GiveTask(GameObject player)
    {
        if (givedQuest) { return; }

        _task = new GoTask("Go to Petya", "Find Petya and talk him something", _placeManager.GetComponent<PlacesLinks>().Petya);
        base.GiveTask(player);
    }
}
