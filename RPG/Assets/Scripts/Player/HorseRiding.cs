using UnityEngine;
using UnityEngine.UI;

public class HorseRiding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button rideHorse;
    [SerializeField] private Button dismountHorse;

    // Bug!!! When you are staying so close to several horses and click "Ride", both horses are coming.

    public void RideHorse()
    {
        this.transform.parent = player.transform; // set parent to player
        this.transform.localPosition = Vector3.zero + new Vector3(0,0,0.5f); //place horse right under player with a little offset
        rideHorse.gameObject.SetActive(false); // hide ride btn
        dismountHorse.gameObject.SetActive(true); //show dismount btn
    }

    public void DismountHorse()
    {
        this.transform.parent = null; //detach horse from player
        dismountHorse.gameObject.SetActive(false); //hide dismount button
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rideHorse.onClick.AddListener(RideHorse);
            dismountHorse.onClick.AddListener(DismountHorse);
            rideHorse.gameObject.SetActive(true); //show ride btn
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rideHorse.onClick.RemoveListener(RideHorse);
            rideHorse.onClick.RemoveListener(DismountHorse);
            rideHorse.gameObject.SetActive(false); //hide ride btn
        }
        
    }
}