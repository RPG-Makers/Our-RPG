using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueUI;
    [SerializeField] private GameObject _contentUI;
    [SerializeField] private GameObject _dialogueElement;

    public void EnableDialogueUI()
    {
        _dialogueUI.SetActive(true);
    }

    public void EnableDialogueUI(string greeting)
    {
        EnableDialogueUI();
        InstantiateDialogueElement(greeting);
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
