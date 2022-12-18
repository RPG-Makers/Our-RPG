using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    private List<Quest> _quests;

    private void Awake()
    {
        _quests = new List<Quest>();
    }

    public void ReceiveQuest(Quest quest)
    {
        _quests.Add(quest);
        Debug.Log("Player have received some quest");
    }

    public void CloseQuest(Quest quest)
    {
        _quests.Remove(quest);
        Debug.Log("Player have closed some quest");
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
