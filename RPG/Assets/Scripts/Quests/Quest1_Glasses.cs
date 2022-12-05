using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1_Glasses : MonoBehaviour
{
    
    public bool glassesFound;
    
    // Start is called before the first frame update
    void Start()
    {
        glassesFound = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        glassesFound = true;
    }
}
