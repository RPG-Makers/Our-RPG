using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private QuestGiverData _data;

    [Header("UI")]
    [SerializeField] private GameObject _dialogueUI;
    [SerializeField] private GameObject _contentUI;
    [SerializeField] private GameObject _dialogueElement;

    public void EnableDialogueUI()
    {
        _dialogueUI.SetActive(true);
        for (int i = 0; i < _contentUI.transform.childCount; i++)
        {
            Destroy(_contentUI.transform.GetChild(0).gameObject);
        }
    }

    public void EnableDialogueUI(string greeting)
    {
        EnableDialogueUI();
        InstantiateDialogueElement(greeting);
        foreach (var dialogue in _data.Dialogues)
        {
            InstantiateDialogueElement(dialogue);
        }
    }

    public void DisableDialogueUI()
    {
        _dialogueUI.SetActive(false);
    }

    public void InstantiateDialogueElement(string text)
    {
        _dialogueElement.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Instantiate(_dialogueElement, _contentUI.transform);
    }
}
