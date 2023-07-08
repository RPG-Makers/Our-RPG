using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public PlayerQuestData Data => data;

    
    [SerializeField] private PlayerQuestData data;

    public void ReceiveQuest(Quest quest)
    {
        data.Quests.Add(quest);
        Debug.Log($"Player has received {quest.QuestData.Name} quest");
    }

    public void CompleteQuest(Quest quest)
    {
        data.Quests.Remove(quest);
        data.CompletedQuests.Add(quest);
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