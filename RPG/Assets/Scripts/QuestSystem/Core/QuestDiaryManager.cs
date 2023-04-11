using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    public void EnableQuestDiaryUI()
    {
        _content.SetActive(true);
        InitializeQuestButtons(GameManager.Instance.PlayerQuest.Data.Quests); // здесь нужно запросить текущие квесты и отобразить.
    }

    private void InitializeQuestButtons(IEnumerable<Quest> quests)
    {
        foreach (var quest in quests)
        {
            GameObject questButton = Instantiate(_questButtonPrefab, _questButtonsParent);
            questButton.GetComponentInChildren<TextMeshProUGUI>().text = quest.QuestData.Name;
        }
    }

    private void InitializeDetails(string questName, string questDescription) // А эту штучку будем привязывать к кнопкам квестов.
    {
        _questName.text = questName;
        _questDescription.text = questDescription;
    }

    public void Disable()
    {
        _questName.text = "";
        _questDescription.text = "";
        _content.SetActive(false);
    }
}
