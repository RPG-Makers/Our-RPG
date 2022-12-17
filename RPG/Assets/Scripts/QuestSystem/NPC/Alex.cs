using UnityEngine;

public class Alex : QuestGiver
{
    protected override void GiveTask(GameObject player)
    {
        if (givedQuest) { return; }

        _task = new GoTask("Check Castle", "This castle is on fire!", _placeManager.GetComponent<PlacesLinks>().Castle);
        base.GiveTask(player);
    }
}
