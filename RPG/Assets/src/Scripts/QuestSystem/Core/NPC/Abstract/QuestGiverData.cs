using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestGiverData", menuName = "QuestSystem/QuestGiverData")]
public class QuestGiverData : ScriptableObject
{
    [Header("QuestSystem")]
    public List<Quest> RemainingQuests = new List<Quest>();

    [Header("DialogueSystem"), Tooltip("First phrases in dialogue")]
    public List<string> FirstPhrases = new List<string>();
    
    #region Unnecessary
    //public Queue<Quest> RemainingQuests = new Queue<Quest>();
    // public Quest CurrentQuest;
    // public bool GivedQuest => CurrentQuest != null;
    // public int AmountOfCompletedQuests;
    #endregion
    
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