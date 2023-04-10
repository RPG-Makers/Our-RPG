using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerQuest))]
public class PlayerQuestUI : MonoBehaviour
{
    [SerializeField] private GameObject _UI;
    private PlayerQuest _playerQuest;

    private void Awake()
    {
        _playerQuest = GetComponent<PlayerQuest>();
    }

    public void ActiveUI()
    {
        _UI.SetActive(true);
        string result = "Quests:\n";
        foreach (var item in _playerQuest._quests)
        {
            result += "- " + item.QuestData.name + "\n";
        }
        _UI.GetComponentInChildren<TextMeshProUGUI>().text = result;
    }

    public void DisableUI()
    {
        _UI.GetComponentInChildren<TextMeshProUGUI>().text = "empty";
        _UI.SetActive(false);
    }
}
