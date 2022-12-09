using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HorseRiding : MonoBehaviour
{
    public GameObject player;
    public GameObject horse;
    public Button rideHorse;
    public Button dismountHorse;


    public void RideHorse()
    {
        transform.parent = player.transform; // set parent to player
        transform.localPosition = Vector3.zero + new Vector3(0,0,0.5f); //place horse right under player with a little offset
        rideHorse.gameObject.SetActive(false); // hide ride btn
        dismountHorse.gameObject.SetActive(true); //show dismount btn
    }

    public void DismountHorse()
    {
        transform.parent = null; //detach horse from player
        dismountHorse.gameObject.SetActive(false); //hide dismount button
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        rideHorse.gameObject.SetActive(true); //show ride btn
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        rideHorse.gameObject.SetActive(false); //hide ride btn
    }


}