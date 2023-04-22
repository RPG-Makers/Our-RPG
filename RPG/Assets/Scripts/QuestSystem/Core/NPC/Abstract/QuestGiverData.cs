using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestGiverData", menuName = "QuestSystem/QuestGiverData")]
public class QuestGiverData : ScriptableObject
{
    [Header("QuestSystem")]
    //public Queue<Quest> RemainingQuests = new Queue<Quest>();
    public List<Quest> RemainingQuests = new List<Quest>();
    public Quest CurrentQuest;
    public bool GivedQuest => CurrentQuest != null;
    public int AmountOfCompletedQuests;

    [Header("DialogueSystem")]
    public string Greeting;
    public List<string> Dialogues = new List<string>();
    public string[] QuestNames
    {
        get
        {
            string[] names = new string[RemainingQuests.Count];
            Quest[] temp = RemainingQuests.ToArray();
            for (int i = 0; i < names.Length; i++)
            {
                names[i] = temp[i].QuestData.Name;
            }
            return names;
        }
    }
}
