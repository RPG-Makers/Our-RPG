using UnityEngine;

public class Sablya : ItemBase
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
