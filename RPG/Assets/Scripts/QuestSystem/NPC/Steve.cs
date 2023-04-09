using UnityEngine;

public class Steve : QuestGiver
{
    private void Start()
    {
        InitializeQuests();
    }

    protected override void InitializeQuests()
    {
        if (_data.RemainingQuests == null)
        {
            Debug.Log("null");
        }
        //_data.RemainingQuests.Add(
        //    new Quest("Revenge",
        //    "Find OldCastle and kill Wizard!",
        //    new Task[2]
        //    {
        //        new GoTask("Find OldCastle", "Find it on the top of mountain", _places.Castle),
        //        new KillTask("Kill Wizard", "He is strong but ok!", "Wizard", 1)
        //    }
        //    ));

        //_data.RemainingQuests.Add(
        //    new Quest("Adventure",
        //    "Walk around and found new spots!",
        //    new Task[2]
        //    {
        //        new GoTask("Mountain", "Find the mountain.", _places.Money1),
        //        new GoTask("River", "Find the river.", _places.Money2)
        //    }
        //    ));
    }

    //protected override void GiveQuest(PlayerQuest player)
    //{
    //    //if (givedQuest) { return; }

    //    //Task[] tasks = new Task[1] { new GoTask("Go to Petya", "Find Petya and talk him something", _placeManager.GetComponent<PlacesLinks>().Petya) };
    //    //_quest = new Quest("Petya", "Talk", tasks);
    //    //base.GiveQuest(player);
    //}
}
