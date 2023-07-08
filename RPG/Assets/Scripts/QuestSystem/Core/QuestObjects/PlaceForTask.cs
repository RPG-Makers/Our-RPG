using System;
using UnityEngine;

public class PlaceForTask : MonoBehaviour
{
    public Action PlayerSpotted;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerQuest>() is not null)
        {
            if (PlayerSpotted is not null)
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
