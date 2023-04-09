using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestGiver", menuName = "QuestSystem/QuestGiver")]
public class QuestGiverData : ScriptableObject
{
    public Queue<Quest> RemainingQuests = new Queue<Quest>();
    public Quest CurrentQuest;
    public bool GivedQuest => CurrentQuest != null;
    public int AmountOfCompletedQuests;

    public string Greeting;
}
