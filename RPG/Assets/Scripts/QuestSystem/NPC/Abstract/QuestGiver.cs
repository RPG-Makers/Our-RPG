using UnityEngine;

//[RequireComponent(typeof(QuestGiverUI))]
[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected PlacesLinks _places;
    [SerializeField] protected QuestGiverData _data;

    //private QuestGiverUI _UI;

    //private void Awake()
    //{
    //    _UI = GetComponent<QuestGiverUI>();
    //}

    protected virtual void GiveQuest(PlayerQuest player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    {
        Quest quest;
        if (_data.RemainingQuests.TryDequeue(out quest))
        {
            _data.CurrentQuest = quest;
            player.ReceiveQuest(_data.CurrentQuest);
        }
        else
        {
            Debug.LogFormat("Пока что квестов нет");
        }
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
