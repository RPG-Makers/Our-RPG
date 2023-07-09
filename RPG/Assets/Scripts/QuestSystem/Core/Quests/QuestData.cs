using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "QuestSystem/QuestData")]
public class QuestData : ScriptableObject
{
    [Header("Info")]
    public string Name;
    public string Description;
    // [Tooltip("Means accept in dialogue with NPC")] public string TextAfterAccept;
    // [Tooltip("Means decline in dialogue with NPC")] public string TextAfterDecline;
    public bool Completed;

    [Header("Tasks")]
    public int AmountOfCompletedTasks;
    public List<Task> Tasks // В будущем можно реализовать это через массив, но кода будет в разы больше. Возможно, импользование массива увеличит быстродействие, а может и наоборот.
    {
        get
        {
            List<Task> tasks = new List<Task>(KillTasks.Count + GoTasks.Count);
            foreach (var task in KillTasks)
                tasks.Add(task);
            foreach (var task in GoTasks)
                tasks.Add(task);
            return tasks;
        }
    }
    public int AmountOfTasks => KillTasks.Count + GoTasks.Count;
    public List<KillTask> KillTasks;
    public List<GoTask> GoTasks;

    private void Awake() // Действительно ли нужно?
    {
        KillTasks = new List<KillTask>();
        GoTasks = new List<GoTask>();
    }
}
