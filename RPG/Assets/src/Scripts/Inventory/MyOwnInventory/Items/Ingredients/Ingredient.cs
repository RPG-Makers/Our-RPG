using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : ItemBase
{
    public override void Use()
    {
        Debug.Log("We have used the ingredient.");
    }
}
