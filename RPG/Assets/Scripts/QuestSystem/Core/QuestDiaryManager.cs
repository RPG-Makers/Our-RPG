using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestDiaryManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _content;

    [Header("Parameters")]
    [SerializeField] private TextMeshProUGUI _questName;
    [SerializeField] private TextMeshProUGUI _questDescription;

    [Header("QuestButtons")]
    [SerializeField] private Transform _questButtonsParent;
    [SerializeField] private GameObject _questButtonPrefab;

    #region API
    public void EnableQuestDiaryUI()
    {
        _content.SetActive(true);
        InstantiateQuestButtons(GameManager.Instance.PlayerQuest.Data.Quests);
    }

    public void Disable()
    {
        _questName.text = "";
        _questDescription.text = "";
        ClearQuestButtons();
        _content.SetActive(false);
    }
    #endregion

    #region Core
    private void InstantiateQuestButtons(IEnumerable<Quest> quests)
    {
        foreach (var quest in quests)
        {
            GameObject questButton = Instantiate(_questButtonPrefab, _questButtonsParent);
            questButton.GetComponentInChildren<TextMeshProUGUI>().text = quest.QuestData.Name;
            questButton.GetComponent<Button>().onClick.AddListener(() => InitializeDetails(quest.QuestData.Name, quest.QuestData.Description));
        }
    }

    private void InitializeDetails(string questName, string questDescription)
    {
        _questName.text = questName;
        _questDescription.text = questDescription;
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