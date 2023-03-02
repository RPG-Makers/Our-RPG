using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Item
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
