using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    private string _name;
    private string _description;
    public bool Completed { get; private set; }

    private Task[] _tasks;
    private int _amountOfCompletedTasks;

    public Quest(string name, string description, Task[] tasks)
    {
        _name = name;
        _description = description;
        _tasks = tasks;
        _amountOfCompletedTasks = 0;
        foreach (Task task in _tasks)
        {
            task.Completed += TaskCompleted;
        }
    }

    private void TaskCompleted()
    {
        _amountOfCompletedTasks++;
        if (_amountOfCompletedTasks == _tasks.Length)
        {
            Completed = true;
            Debug.Log($"Quest {_name} completed");
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
