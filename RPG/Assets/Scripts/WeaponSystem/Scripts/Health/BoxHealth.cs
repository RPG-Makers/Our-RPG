using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : Health
{
    protected override void Death()
    {
        Debug.Log("Box did something after death.");
    }
}
