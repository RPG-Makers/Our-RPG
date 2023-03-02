using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(QuestGiver))]
public class QuestGiverUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _UI;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _talkButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _receiveRewardButton;
    [SerializeField] private Button _receiveQuestButton;

    private QuestGiver _questGiver;

    private void Awake()
    {
        _questGiver = GetComponent<QuestGiver>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Тут уже скорее всего нужно будет взаимодействовать с UI и включать кнопки, к которым подвязаны различные методы.
        if (collision.CompareTag("Player"))
        {
            _talkButton.enabled = true;
        }

        if (collision.CompareTag("Player"))
        {

            //// Допустим, выдаём квест сразу как игрок зайдет в триггер.
            //if (!givedQuest)
            //{
            //    GiveQuest(collision.gameObject);
            //}
            //else if (givedQuest && _quest.QuestData.Completed)
            //{
            //    Debug.Log("Thank you!");
            //}
            //else
            //{
            //    Debug.Log("You didn't complete my quest!");
            //}
        }
    }
}
