using UnityEngine;

public class Alex : QuestGiver
{
    protected override void GiveQuest(GameObject player)
    {
        if (givedQuest) { return; }
        Task[] tasks = new Task[1] { new GoTask("Check Castle", "This castle is on fire!", _placeManager.GetComponent<PlacesLinks>().Castle) };
        _quest = new Quest("Castle", "Check castle", tasks);
        base.GiveQuest(player);
    }
}
