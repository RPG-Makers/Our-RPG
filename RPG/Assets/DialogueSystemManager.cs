using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystemManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _dialogueUI;
    [SerializeField] private GameObject _contentUI;
    [SerializeField] private GameObject _dialogueElement;

    public void EnableDialogueUI()
    {
        _dialogueUI.SetActive(true);
        
    }

    public void EnableDialogueUI(string greeting, List<string> dialogues)
    {
        EnableDialogueUI();
        InstantiateDialogueElement(greeting);
        foreach (var dialogue in dialogues)
        {
            InstantiateDialogueElement(dialogue);
        }
    }

    public void DisableDialogueUI()
    {
        for (int i = 0; i < _contentUI.transform.childCount; i++)
        {
            Destroy(_contentUI.transform.GetChild(i).gameObject);
        }
        _dialogueUI.SetActive(false);
    }

    public void InstantiateDialogueElement(string text)
    {
        _dialogueElement.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Instantiate(_dialogueElement, _contentUI.transform);
    }
}
