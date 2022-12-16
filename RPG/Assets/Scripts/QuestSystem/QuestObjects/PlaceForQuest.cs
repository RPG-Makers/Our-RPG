using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceForQuest : MonoBehaviour
{
    public Action PlayerSpotted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerSpotted != null)
            {
                PlayerSpotted?.Invoke();
            }
            else
            {
                Debug.Log("А тебя никто не звал сюда!");
            }
        }
    }
}
