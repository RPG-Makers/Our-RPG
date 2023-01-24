using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest
{
    public QuestData QuestData { get; private set; }

    public Quest(string name, string description, Task[] tasks)
    {
        QuestData = ScriptableObject.CreateInstance<QuestData>(); // Сейчас это не сохраняется! В будущем как-либо изменить!
        QuestData.Name = name;
        QuestData.Description = description;
        QuestData.Tasks = tasks;
        QuestData.AmountOfCompletedTasks = 0;
        foreach (Task task in QuestData.Tasks)
        {
            task.Completed += TaskCompleted;
        }
    }

    private void TaskCompleted()
    {
        QuestData.AmountOfCompletedTasks++;
        if (QuestData.AmountOfCompletedTasks == QuestData.Tasks.Length)
        {
            QuestData.Completed = true;
            Debug.Log($"Quest {QuestData.Name} completed");
        }
    }

    //public Task[] GetTasks()
    //{
    //    return _tasks;
    //    //List<Task> tasks = new List<Task>();
    //    //foreach (Task task in _tasks)
    //    //{
    //    //    tasks.Add(task);
    //    //}
    //    //return tasks;
    //}
}
