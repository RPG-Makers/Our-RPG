using UnityEngine;

public class Kusarigama : ItemBase
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
