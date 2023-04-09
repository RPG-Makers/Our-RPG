using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystemManager : MonoBehaviour
{
    // Скорее всего в будущем будет один метод, который будет вызываться извне и генерировать все необходимые диалоги и ответы.
    [Header("UI")]
    [SerializeField] private GameObject _dialogueUI;

    [Header("Dialogues")]
    [SerializeField] private GameObject _dialoguesParent;
    [SerializeField] private GameObject _dialogueElement;

    [Header("Answers")]
    [SerializeField] private GameObject _answerButtonsParent;
    [SerializeField] private GameObject _answerButton;

    #region Dialogue
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
        for (int i = 0; i < _dialoguesParent.transform.childCount; i++)
        {
            Destroy(_dialoguesParent.transform.GetChild(i).gameObject);
        }
        _dialogueUI.SetActive(false);
    }

    public void InstantiateDialogueElement(string text)
    {
        _dialogueElement.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Instantiate(_dialogueElement, _dialoguesParent.transform);
    }
    #endregion

    public void InstantiateAnswerButton(string text)
    {
        _answerButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Instantiate(_answerButton, _answerButtonsParent.transform);
    }
}
