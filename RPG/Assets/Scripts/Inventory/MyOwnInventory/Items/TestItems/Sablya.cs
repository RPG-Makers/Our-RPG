using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sablya : Item
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
