using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDiaryManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _questDiaryUI;

    [Header("Parameters")]
    [SerializeField] private TextMeshProUGUI _questName;
    [SerializeField] private TextMeshProUGUI _questDescription;

    [Header("QuestButtons")]
    [SerializeField] private Transform _questButtonsParent;
    [SerializeField] private GameObject _questButtonPrefab;

    #region API
    public void EnableQuestDiaryUI()
    {
        _questDiaryUI.SetActive(true);
        InstantiateQuestButtons();
    }

    public void InstantiateQuestButtons()
    {
        ClearDetails();
        ClearQuestButtons();
        foreach (var quest in GameManager.Instance.PlayerQuest.Data.Quests)
        {
            GameObject questButton = Instantiate(_questButtonPrefab, _questButtonsParent);
            questButton.GetComponentInChildren<TextMeshProUGUI>().text = quest.QuestData.Name;
            questButton.GetComponent<Button>().onClick.AddListener(() => InitializeDetails(quest.QuestData.Name, quest.QuestData.Description));
        }
    }

    public void InstantiateCompletedQuestButtons()
    {
        ClearDetails();
        ClearQuestButtons();
        foreach (var quest in GameManager.Instance.PlayerQuest.Data.CompletedQuests)
        {
            GameObject questButton = Instantiate(_questButtonPrefab, _questButtonsParent);
            questButton.GetComponentInChildren<TextMeshProUGUI>().text = quest.QuestData.Name;
            questButton.GetComponent<Button>().onClick.AddListener(() => InitializeDetails(quest.QuestData.Name, quest.QuestData.Description));
        }
    }

    public void Disable()
    {
        ClearDetails();
        ClearQuestButtons();
        _questDiaryUI.SetActive(false);
    }
    #endregion

    #region Core
    private void InitializeDetails(string questName, string questDescription)
    {
        _questName.text = questName;
        _questDescription.text = questDescription;
    }

    private void ClearDetails()
    {
        _questName.text = "";
        _questDescription.text = "";
    }

    private void ClearQuestButtons()
    {
        for (int i = 0; i < _questButtonsParent.childCount; i++)
        {
            Destroy(_questButtonsParent.GetChild(i).gameObject);
        }
    }
    #endregion
}