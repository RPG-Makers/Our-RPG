using UnityEngine;

public class test2 : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.SomeAction.Subscribe(Method);
    }

    private void OnDisable()
    {
        EventBus.SomeAction.Unsubscribe(Method);
    }

    private void Method()
    {
        Debug.Log("Method");
    }
}
