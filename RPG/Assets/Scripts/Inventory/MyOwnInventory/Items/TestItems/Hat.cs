using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Item
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
