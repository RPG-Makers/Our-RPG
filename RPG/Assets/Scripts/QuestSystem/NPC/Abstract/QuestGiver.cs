using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected PlayerQuest _playerQuest; // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [SerializeField] protected PlacesLinks _places;
    [SerializeField] protected QuestGiverData _data;

    protected abstract void InitializeQuests();

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

    public void GiveQuest(int index)
    {
        if (index < 0 || index > _data.RemainingQuests.Count)
        {
            Debug.LogWarning("Incorrect index");
            return;
        }
        ScriptStorage.Instance.PlayerQuest.ReceiveQuest(_data.RemainingQuests[index]);
    }

    private void OnMouseDown()
    {
        //ScriptStorage.Instance.DialogueSystemManager.InitializeDialogueSystem(_data.Greeting, _data.Dialogues, new List<string>() { "answer TEST" });
        ScriptStorage.Instance.DialogueSystemManager.InitializeDialogueSystem(_data, this);

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
}
