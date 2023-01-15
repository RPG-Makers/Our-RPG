using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "QuestSystem/Quest")]
public class QuestData : ScriptableObject
{
    public string Name;
    public string Description;
    public bool Completed;

    public Task[] Tasks;
    public int AmountOfCompletedTasks;
}
