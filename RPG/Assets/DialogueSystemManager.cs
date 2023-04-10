using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystemManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _dialogueUI;

    [Header("Dialogues")]
    [SerializeField] private GameObject _dialoguesParent;
    [SerializeField] private GameObject _dialogueElement;

    [Header("Answers")]
    [SerializeField] private GameObject _answerButtonsParent;
    [SerializeField] private GameObject _answerButton;

    private QuestGiverData tempData;
    private QuestGiver tempQuestGiver;
    private void EnableDialogueSystemUI()
    {
        _dialogueUI.SetActive(true);
    }

    #region API
    public void Disable()
    {
        ClearDialogueUI();
        ClearAnswersUI();
        _dialogueUI.SetActive(false);
    }

    //public void InitializeDialogueSystem(string greeting, List<string> dialogues, List<string> answers)
    //{
    //    EnableDialogueSystemUI();
    //    InitializeDialogues(greeting, dialogues);
    //    InitializeAnswers(answers);
    //}

    public void InitializeDialogueSystem(QuestGiverData data, QuestGiver questGiver)
    {
        tempData = data; tempQuestGiver = questGiver;
        EnableDialogueSystemUI();
        ClearDialogueUI();
        ClearAnswersUI();
        InitializeDialogues(data.Greeting, data.Dialogues);
        InitializeAnswers(data.QuestNames, questGiver);
    }
    #endregion

    #region Dialogue
    private void InitializeDialogues(string greeting, List<string> dialogues)
    {
        InstantiateDialogueElement(greeting);
        foreach (var dialogue in dialogues)
        {
            InstantiateDialogueElement(dialogue);
        }
    }
    private void InstantiateDialogueElement(string text)
    {
        _dialogueElement.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Instantiate(_dialogueElement, _dialoguesParent.transform);
    }
    private void ClearDialogueUI()
    {
        for (int i = 0; i < _dialoguesParent.transform.childCount; i++)
        {
            Destroy(_dialoguesParent.transform.GetChild(i).gameObject);
        }
    }
    #endregion

    #region Answers
    private void InitializeAnswers(string[] answers, QuestGiver questGiver)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            InstantiateQuestButton(answers[i], i, questGiver);
        }
        //foreach (var answer in answers)
        //{
        //    InstantiateAnswerButton(answer);
        //}
    }
    // При нажатии на кнопку квеста:
    // 1) Спавним диалог (текст = описание квеста)
    // 2) Спавним две кнопки:
    //          а. Да (взятие квеста)
    //          б. Нет (возврат к предыдущему состоянию)
    private void InstantiateQuestButton(string text, int indexOfQuest, QuestGiver questGiver)
    {
        GameObject button = Instantiate(_answerButton, _answerButtonsParent.transform);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text;
        button.GetComponent<Button>().onClick.AddListener(() => InstantiateAnswersButtons(text, indexOfQuest, questGiver));
        button.GetComponent<Button>().onClick.AddListener(() => Destroy(button));
    }
    private void InstantiateAnswersButtons(string text, int indexOfQuest, QuestGiver questGiver)
    {
        ClearAnswersUI();
        // а еще надо переименовать параметр "text".
        GameObject acceptButton = Instantiate(_answerButton, _answerButtonsParent.transform);
        acceptButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Accept {text} quest";
        acceptButton.GetComponent<Button>().onClick.AddListener(() => questGiver.GiveQuest(indexOfQuest));
        acceptButton.GetComponent<Button>().onClick.AddListener(() => InitializeDialogueSystem(tempData, tempQuestGiver));

        GameObject declineButton = Instantiate(_answerButton, _answerButtonsParent.transform);
        declineButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Decline {text} quest";
        declineButton.GetComponent<Button>().onClick.AddListener(() => InitializeDialogueSystem(tempData, tempQuestGiver));
    }
    private void ClearAnswersUI()
    {
        for (int i = 0; i < _answerButtonsParent.transform.childCount; i++)
        {
            Destroy(_answerButtonsParent.transform.GetChild(i).gameObject);
        }
    }
    #endregion

    public void Test(string text)
    {
        Debug.Log(text);
    }
}