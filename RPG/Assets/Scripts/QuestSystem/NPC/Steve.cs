using UnityEngine;

public class Steve : QuestGiver
{
    protected override void GiveQuest(GameObject player)
    {
        if (givedQuest) { return; }

        _quest = new GoQuest("Go to Petya", "Find Petya and talk him something", _placeManager.GetComponent<PlacesLinks>().Petya);
        player.GetComponent<PlayerQuest>().ReceiveQuest(_quest);
        //_quest = null;
        givedQuest = true;
    }
}
