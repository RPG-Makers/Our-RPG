using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected QuestGiverData _data;

    public void GiveQuest(int index)
    {
        if (index < 0 || index > _data.RemainingQuests.Count)
        {
            Debug.LogWarning("Incorrect index");
            return;
        }
        GameManager.Instance.PlayerQuest.ReceiveQuest(_data.RemainingQuests[index]);
    }

    private void OnMouseDown()
    {
        //ScriptStorage.Instance.DialogueSystemManager.InitializeDialogueSystem(_data.Greeting, _data.Dialogues, new List<string>() { "answer TEST" });
        GameManager.Instance.DialogueSystemManager.InitializeDialogueSystem(_data, this);

        // Old
        //if (!_data.GivedQuest)
        //{
        //    Debug.Log("Try to give a Quest");
        //    GiveQuest(_playerQuest);
        //}
        //else
        //{
        //    Debug.Log("Will not give a Quest");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) // Temp!!!! Move to UI component!
    {
        //if (collision.CompareTag("Player"))
        //{
        //    if (!givedQuest)
        //    {
        //        GiveQuest(collision.gameObject);
        //    }
        //    else if (givedQuest && _quest.QuestData.Completed)
        //    {
        //        Debug.Log("Thank you!");
        //    }
        //    else
        //    {
        //        Debug.Log("You didn't complete my quest!");
        //    }
        //}
    }
    #region GiveQuest by Queue
    // Using Queue.
    //protected virtual void GiveQuest(PlayerQuest player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    //{
    //    Quest quest;
    //    if (_data.RemainingQuests.TryDequeue(out quest))
    //    {
    //        _data.CurrentQuest = quest;
    //        player.ReceiveQuest(_data.CurrentQuest);
    //    }
    //    else
    //    {
    //        Debug.LogFormat("Пока что квестов нет");
    //    }
    //}
    #endregion
    #region CreatingQuestsFromScript
    // Note: Quest._questData would be null!
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
    #endregion
}
