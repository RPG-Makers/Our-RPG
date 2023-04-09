using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerQuestUI))]
public class PlayerQuest : MonoBehaviour
{
    public List<Quest> _quests; // !!!!!!!!!!!!!!!!!!!!!! public

    private void Awake()
    {
        _quests = new List<Quest>();
    }

    public void ReceiveQuest(Quest quest)
    {
        _quests.Add(quest);
        Debug.Log(quest.QuestData.name);
        Debug.Log("Player has received some quest");
    }

    public void CloseQuest(Quest quest)
    {
        _quests.Remove(quest);
        Debug.Log("Player has finished some quest");
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