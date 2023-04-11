using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestDiaryManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _questDiaryUI;

    [Header("Parameters")]
    [SerializeField] private TextMeshProUGUI _questName;
    [SerializeField] private TextMeshProUGUI _questDescription;

    public void InitializeDetails(string questName, string questDescription)
    {
        _questName.text = questName;
        _questDescription.text = questDescription;
    }

    public void InitializeQuests(IEnumerable<Quest> quests)
    {

    }

    public void EnableQuestDiaryUI()
    {
        _questDiaryUI.SetActive(true);
    }

    public void Disable()
    {
        _questName.text = "";
        _questDescription.text = "";
        _questDiaryUI.SetActive(false);
    }
}
