using System.Collections;
using System.Collections.Generic;
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
}
