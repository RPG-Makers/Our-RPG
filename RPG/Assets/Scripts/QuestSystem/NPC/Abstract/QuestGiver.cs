using UnityEngine;

public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected GameObject _placeManager;

    // QuestSystem settings
    protected Task _task;
    protected bool givedQuest;

    protected virtual void GiveTask(GameObject player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    {
        player.GetComponent<PlayerTask>().ReceiveTask(_task);
        //_quest = null;
        givedQuest = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Допустим, выдаём квест сразу как игрок зайдет в триггер.
            if (!givedQuest)
            {
                GiveTask(collision.gameObject);
            }
            else if (givedQuest && _task.Completed)
            {
                Debug.Log("Thank you!");
            }
            else
            {
                Debug.Log("You didn't complete my task!");
            }
        }
    }
}
