using UnityEngine;

//[RequireComponent(typeof(QuestGiverUI))]
[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected GameObject _placeManager;
    [SerializeField] private QuestGiverData _data;

    protected Quest _quest;
    protected bool givedQuest;





    protected virtual void GiveQuest(GameObject player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    {
        player.GetComponent<PlayerQuest>().ReceiveQuest(_quest);






        // new system
        //Quest quest;
        //if (_data.RemainingQuests.TryDequeue(out quest))
        //{
        //    _data.CurrentQuest = quest;
        //    player.GetComponent<PlayerQuest>().ReceiveQuest(_data.CurrentQuest);
        //}
        //else
        //{
        //    Debug.LogFormat("Пока что квестов нет");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision) // Temp!!!! Move to UI component!
    {
        if (collision.CompareTag("Player"))
        {
            if (!givedQuest)
            {
                GiveQuest(collision.gameObject);
            }
            else if (givedQuest && _quest.QuestData.Completed)
            {
                Debug.Log("Thank you!");
            }
            else
            {
                Debug.Log("You didn't complete my quest!");
            }
        }
    }
}
