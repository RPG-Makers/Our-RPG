using UnityEngine;

public abstract class QuestGiver : MonoBehaviour
{
    [SerializeField] protected GameObject _placeManager;
    [SerializeField] private QuestGiverData _data;
    

    protected virtual void GiveQuest(GameObject player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    {
        Quest quest;
        if (_data.RemainingQuests.TryDequeue(out quest))
        {
            _data.CurrentQuest = quest;
            player.GetComponent<PlayerQuest>().ReceiveQuest(_data.CurrentQuest);
        }
        else
        {
            Debug.LogFormat("Пока что квестов нет");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Тут уже скорее всего нужно будет взаимодействовать с UI и включать кнопки, к которым подвязаны различные методы.
        if (collision.CompareTag("Player"))
        {
            //// Допустим, выдаём квест сразу как игрок зайдет в триггер.
            //if (!givedQuest)
            //{
            //    GiveQuest(collision.gameObject);
            //}
            //else if (givedQuest && _quest.QuestData.Completed)
            //{
            //    Debug.Log("Thank you!");
            //}
            //else
            //{
            //    Debug.Log("You didn't complete my quest!");
            //}
        }
    }
}
