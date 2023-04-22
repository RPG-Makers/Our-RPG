using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestData", menuName = "QuestSystem/QuestData")]
public class QuestData : ScriptableObject
{
    public string Name;
    public string Description;
    public bool Completed;

    public List<Task> Tasks // � ������� ����� ����������� ��� ����� ������, �� ���� ����� � ���� ������. ��������, ������������� ������� �������� ��������������, � ����� � ��������.
    {
        get
        {
            List<Task> tasks = new List<Task>(KillTasks.Count + GoTasks.Count);
            foreach (var task in KillTasks)
            {
                tasks.Add(task);
            }
            foreach (var task in GoTasks)
            {
                tasks.Add(task);
            }
            return tasks;
        }
    }
    public int AmountOfTasks => KillTasks.Count + GoTasks.Count;
    public int AmountOfCompletedTasks;
    public List<KillTask> KillTasks;
    public List<GoTask> GoTasks;

    private void Awake() // ������������� �� �����?
    {
        KillTasks = new List<KillTask>();
        GoTasks = new List<GoTask>();
    }
}
