using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : Health
{
    public static Action Died;
    protected override void Death()
    {
        Died.Invoke();
        Debug.Log("Box did something after death.");
    }
}
