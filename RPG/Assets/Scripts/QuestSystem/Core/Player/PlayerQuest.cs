using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    [SerializeField] private PlayerQuestData _data;
    public PlayerQuestData Data => _data;

    public void ReceiveQuest(Quest quest)
    {
        _data.Quests.Add(quest);
        Debug.Log(quest.QuestData.Name);
        Debug.Log("Player has received some quest");
    }

    public void CloseQuest(Quest quest)
    {
        _data.Quests.Remove(quest);
        _data.CompletedQuests.Add(quest);
        _data.NumberOfCompletedQuests++;
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