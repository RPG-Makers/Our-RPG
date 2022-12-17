using UnityEngine;

public class Alex : QuestGiver
{
    protected override void GiveQuest(GameObject player)
    {
        if (givedQuest) { return; }

        _quest = new GoQuest("Check Castle", "This castle is on fire!", _placeManager.GetComponent<PlacesLinks>().Castle);
        base.GiveQuest(player);
    }
}
