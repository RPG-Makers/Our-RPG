using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : Item
{
    protected override void Use()
    {
        Debug.Log("We have used the ingredient.");
    }
}
