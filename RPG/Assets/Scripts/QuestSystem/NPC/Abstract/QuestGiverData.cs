using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestGiver", menuName = "QuestSystem/QuestGiver")]
public class QuestGiverData : ScriptableObject
{
    [Header("QuestSystem")]
    public Queue<Quest> RemainingQuests = new Queue<Quest>();
    public Quest CurrentQuest;
    public bool GivedQuest => CurrentQuest != null;
    public int AmountOfCompletedQuests;

    [Header("DialogueSystem")]
    public string Greeting;
    public List<string> Dialogues = new List<string>();

    private void Reset()
    {
        Debug.Log("Reseted");
        Greeting = "reseted";
    }
}
