using UnityEngine;

public class BoxHealth : Health
{
    protected override void Death()
    {
        EventBus.BoxDeath.Publish();
        Debug.Log("Box did something after death.");
    }
}
