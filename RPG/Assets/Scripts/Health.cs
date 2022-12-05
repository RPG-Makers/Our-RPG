using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    public void getHit(int damage)
    {
        Debug.Log("We are in the getHit!");
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Enemy dead");
            Destroy(gameObject);
        }
    }
}