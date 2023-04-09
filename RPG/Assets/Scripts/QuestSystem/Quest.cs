using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Quest
{
    public QuestData QuestData => _questData; // ����� ���� �����, ���� �� �������� QuestData, �� ����� ����� ������ � ������ ��� ���� ����� ��������. ����� ���������� �������� ����, ����� ������ ������ ���� �����. �� ���� ��� ������� � QuestData ������ ���� ������ ���������� � QuestData.Name, QuestData.Description � ��� �����.
    [SerializeField] private QuestData _questData; // ����� ��������, ����� �� ������� [SerializeField].

    public Quest(string name, string description, Task[] tasks)
    {
        _questData = ScriptableObject.CreateInstance<QuestData>(); // ������ ��� �� �����������! � ������� ���-���� ��������!
        _questData.Name = name;
        //Debug.Log(QuestData.Name);
        _questData.Description = description;
        //QuestData.Tasks = tasks; �������� �������� ��������� ���������� ��� ������ ��� Task � ����� ������������.
        foreach (var task in tasks)
        {
            if (task is KillTask)
            {
                _questData.KillTasks.Add(task as KillTask);
            }
            else if (task is GoTask)
            {
                _questData.GoTasks.Add(task as GoTask);
            }
            else
            {
                Debug.LogWarning("Undefined type of task!");
            }
        }
        _questData.AmountOfCompletedTasks = 0;
        foreach (Task task in _questData.Tasks)
        {
            task.Completed += TaskCompleted;
        }
    }

    private void TaskCompleted()
    {
        _questData.AmountOfCompletedTasks++;
        if (_questData.AmountOfCompletedTasks == _questData.AmountOfTasks)
        {
            _questData.Completed = true;
            Debug.Log($"Quest {_questData.Name} completed");
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
