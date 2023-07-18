using UnityEngine;

public class Orrery : ItemBase
{
    public override void Use()
    {
        Debug.Log($"Used {this.GetType()}");
    }
}
