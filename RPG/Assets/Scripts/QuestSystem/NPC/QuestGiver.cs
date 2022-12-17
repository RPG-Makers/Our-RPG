using UnityEngine;

public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected int id;
    [SerializeField] protected GameObject _placeManager;

    // QuestSystem settings
    protected Quest _quest;
    protected bool givedQuest;

    protected abstract void GiveQuest(GameObject player); // Target is to whom we give the quest. But we are planning to give a quests only to player.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Допустим, выдаём квест сразу как игрок зайдет в триггер.
            if (!givedQuest)
            {
                GiveQuest(collision.gameObject);
            }
            else if (givedQuest && _quest.Completed)
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
