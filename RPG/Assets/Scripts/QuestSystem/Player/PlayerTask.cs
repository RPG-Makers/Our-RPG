using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTask : MonoBehaviour
{
    private List<Task> _tasks;

    private void Awake()
    {
        _tasks = new List<Task>();
    }

    public void ReceiveTask(Task task)
    {
        _tasks.Add(task);
        Debug.Log("Player have received some task");
    }

    public void CloseQuest(Task task)
    {
        _tasks.Remove(task);
        Debug.Log("Player have closed some task");
    }
}
