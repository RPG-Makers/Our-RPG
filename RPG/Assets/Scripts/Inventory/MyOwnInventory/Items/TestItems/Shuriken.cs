using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : ItemBase
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
