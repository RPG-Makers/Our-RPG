using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestGiver", menuName = "QuestSystem/QuestGiver")]
public class QuestGiverData : ScriptableObject
{
    public Queue<Quest> RemainingQuests;
    public Quest CurrentQuest;
    public bool ActiveQuest => CurrentQuest != null;
    public int AmountOfCompletedQuests;
}
