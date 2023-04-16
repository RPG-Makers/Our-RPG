using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [Header("Scripts")]
    public DialogueSystemManager DialogueSystemManager;
    public PlayerQuest PlayerQuest;
    public PlacesLinks PlacesLinks;
    public QuestDiaryManager QuestDiaryManager;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
}
