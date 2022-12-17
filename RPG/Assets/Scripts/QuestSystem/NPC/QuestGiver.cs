using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private int id;
    private string _name;

    // QuestSystem settings
    private Quest _quest;
    private bool givedQuest;

    [SerializeField] private GameObject _placeManager;

    private void GiveQuest(GameObject player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    {
        if (givedQuest) { return; }

        switch (id)
        {
            case 0:
                _quest = new GoQuest("Go to Petya", "Find Petya and talk him something", _placeManager.GetComponent<PlacesLinks>().Petya);
                break;
            case 1:
                _quest = new GoQuest("Check Castle", "This castle is on fire!", _placeManager.GetComponent<PlacesLinks>().Castle);
                break;
            default:
                Debug.LogWarning("Uknown id!");
                break;
        }

        player.GetComponent<PlayerQuest>().ReceiveQuest(_quest);
        _quest = null;
        givedQuest = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Допустим, выдаём квест сразу как игрок зайдет в триггер.
            GiveQuest(collision.gameObject);
        }
    }
}
