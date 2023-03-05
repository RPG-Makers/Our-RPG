using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerQuestUI))]
public class PlayerQuest : MonoBehaviour
{
    private List<Quest> _quests;
    private PlayerQuestUI _UI;

    private void Awake()
    {
        _quests = new List<Quest>();
        _UI = GetComponent<PlayerQuestUI>();
    }

    public void ReceiveQuest(Quest quest)
    {
        _quests.Add(quest);
        Debug.Log("Player has received some quest");
    }

    public void CloseQuest(Quest quest)
    {
        _quests.Remove(quest);
        Debug.Log("Player has finished some quest");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.GetComponent<NPC>())
        _UI.gameObject.SetActive(true);
    }
    //public List<Task> GetAllTasks() // From whole quests.
    //{
    //    List<Task> tasks = new List<Task>();
    //    foreach (Quest quest in _quests)
    //    {
    //        tasks.AddRange(quest.GetTasks());
    //    }
    //    return tasks;
    //}
}
