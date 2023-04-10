using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerQuestData", menuName = "QuestSystem/PlayerQuestData")]
public class PlayerQuestData : ScriptableObject
{
    public List<Quest> Quests = new List<Quest>();
    public List<Quest> CompletedQuests = new List<Quest>();
    public int NumberOfCompletedQuests;
}
