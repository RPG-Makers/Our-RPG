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
        
        glassesItem = GameObject.Find("Glasses Quest 1");
        simpleDialogue.onClick.AddListener(ShowSimpleDialogue);
        nextSimpleDialogue.onClick.AddListener(ShowNextSimpleDialogue);
        closeAllDialogue.onClick.AddListener(closeAllDialogueFunc);
        startQuest1.onClick.AddListener(StartQuest1);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        menu.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        dialogue1.gameObject.SetActive(true);
        closeAllDialogue.gameObject.SetActive(true);
    }


    public void ShowSimpleDialogue()
    {
        dialogue1.gameObject.SetActive(false);
        simpleText1.gameObject.SetActive(true);
        nextSimpleDialogue.gameObject.SetActive(true);
        closeAllDialogue.gameObject.SetActive(true);
    }

    public void ShowNextSimpleDialogue()
    {
        nextSimpleDialogue.gameObject.SetActive(false);
        simpleText1.gameObject.SetActive(false);
        simpleText2.gameObject.SetActive(true);
    }

    public void closeAllDialogueFunc()
    {
        nextSimpleDialogue.gameObject.SetActive(false);
        simpleText1.gameObject.SetActive(false);
        simpleText2.gameObject.SetActive(false);
        questText1.gameObject.SetActive(false);
        questText2.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        background.gameObject.SetActive(false);
    }

    public void StartQuest1()
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