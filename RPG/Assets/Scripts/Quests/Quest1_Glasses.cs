using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1_Glasses : MonoBehaviour
{
    
    public bool glassesFound;
    
    
    void Start()
    {
        glassesFound = false; //очки не найдены игроком
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false); //нашли очки, удалили со сцены, сменили стадию очков на найденные, можно идти сдавать квест первому нпц
        glassesFound = true;
        EventDelegateExample.onFirstQuestItemFound?.Invoke(); // practising with delegates by telling player has found the item for 1st quest
    }
}
