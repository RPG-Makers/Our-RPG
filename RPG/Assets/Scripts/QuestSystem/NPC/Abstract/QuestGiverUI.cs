using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(QuestGiver))]
public class QuestGiverUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _UI;
    [SerializeField] private Button _talkButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _receiveRewardButton;
    [SerializeField] private Button _receiveQuestButton;

    private QuestGiver _questGiver;

    private void Awake()
    {
        _questGiver = GetComponent<QuestGiver>();
    }
}
