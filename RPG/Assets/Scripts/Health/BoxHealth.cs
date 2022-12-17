using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHealth : Health
{
    protected override void Death()
    {
        playerStatistics.NumberOfDestroyedBoxes++;
        Debug.Log("Box did something after death.");
    }
}
