using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Quest1 : MonoBehaviour
{
    public GameObject dialogue1;
    public GameObject simpleText1;
    public GameObject simpleText2;
    public GameObject questText1;
    public GameObject questText2;

    public GameObject menu;
    public GameObject background;

    public Button simpleDialogue;
    public Button nextSimpleDialogue;
    public Button closeAllDialogue;
    public Button startQuest1;

    public GameObject glassesItem;


    private void Start()
    {
        glassesItem = GameObject.Find("Glasses Quest 1"); //предмет "очки" для выполнения первого квеста
        //simpleDialogue.onClick.AddListener(ShowSimpleDialogue); реализовал через юнити редактор
        nextSimpleDialogue.onClick.AddListener(ShowNextSimpleDialogue);
        closeAllDialogue.onClick.AddListener(closeAllDialogueFunc);
        startQuest1.onClick.AddListener(StartQuest1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        menu.gameObject.SetActive(true); //подошли к нпц, открываем диалоговое окно с ним
        background.gameObject.SetActive(true); //включаем подложку-затемнение фона
        dialogue1.gameObject.SetActive(true); //приветствие от нпц и кнопки взаимодействия с ним
        closeAllDialogue.gameObject.SetActive(true); //кнопка закрытия диалогового окна с нпц
    }

    private void OnEnable()
    {
        EventDelegateExample.onFirstQuestItemFound += ConsoleMessage;
    }

    private void OnDisable()
    {
        EventDelegateExample.onFirstQuestItemFound -= ConsoleMessage;
    }

    private void ConsoleMessage()
    {
        Debug.Log("Игрок нашёл квестовый предмет 'Очки' для первого квеста");
    }

    //реализовал через юнити редактор
    /*public void ShowSimpleDialogue()
    {
        dialogue1.gameObject.SetActive(false);
        simpleText1.gameObject.SetActive(true);
        nextSimpleDialogue.gameObject.SetActive(true);
        closeAllDialogue.gameObject.SetActive(true);
    }*/

    //одна кнопка переключения на следующий диалог, поэтому перелистываем текст в диалоге кодом, а не через юнити редактор
    //если на каждый квест или на каждый нпц будет свой отдельный набор кнопок, то можно реализовать через редактор юнити
    public void ShowNextSimpleDialogue()
    {
        nextSimpleDialogue.gameObject.SetActive(false);
        simpleText1.gameObject.SetActive(false);
        simpleText2.gameObject.SetActive(true);
    }

    public void closeAllDialogueFunc() //выключаем все диалоговые UI на сцене
    {
        nextSimpleDialogue.gameObject.SetActive(false);
        simpleText1.gameObject.SetActive(false);
        simpleText2.gameObject.SetActive(false);
        questText1.gameObject.SetActive(false);
        questText2.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    public void
        StartQuest1() //прожали кнопку старта квеста. сразу проверяем, если предмет "очки" найден, квест тут же считается выполненным
    {
        if (glassesItem.GetComponent<Quest1_Glasses>().glassesFound)
        {
            dialogue1.gameObject.SetActive(false);
            questText2.gameObject.SetActive(true);
            closeAllDialogue.gameObject.SetActive(true);
        }
        else
        {
            dialogue1.gameObject.SetActive(false);
            questText1.gameObject.SetActive(true);
            closeAllDialogue.gameObject.SetActive(true);
        }
    }
}