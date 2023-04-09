using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptStorage : MonoBehaviour
{
    public static ScriptStorage Instance = null;

    [Header("Scripts")]
    public DialogueSystemManager DialogueSystemManager;
    public PlayerQuest PlayerQuest;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
}
