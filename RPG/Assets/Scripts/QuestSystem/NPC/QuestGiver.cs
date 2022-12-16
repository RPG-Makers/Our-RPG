using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    private string _name;
    private Quest _quest;


    [SerializeField] private GameObject placeToGo;
    [SerializeField] private int id;
    private bool givedQuest;


    private void GiveQuest(GameObject player) // Target is to whom we give the quest. But we are planning to give a quests only to player.
    {
        // Need to change the place of initializing of quest!!!
        if (givedQuest)
        {
            return;
        }
        if (id == 14)
        {
            GoQuest goQuest = new GoQuest("Go to Petya", "Find Petya and talk him something", placeToGo.GetComponent<PlaceForQuest>());
            givedQuest = true;
        }
        else if (id == 32)
        {
            GoQuest goQuest = new GoQuest("Check Castle", "This castle is on fire!", placeToGo.GetComponent<PlaceForQuest>());
            givedQuest = true;
        }
        // Need to change the place of initializing of quest!!!

        player.GetComponent<PlayerQuest>().ReceiveQuest(_quest);
        _quest = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("В меня что-то вошло");
        if (collision.CompareTag("Player"))
        {
            // Допустим, выдаём квест сразу как игрок зайдет в триггер.
            //Debug.Log("Player in NPC");
            GiveQuest(collision.gameObject);
        }
    }
}
