using System.Collections;
using UnityEngine;

public class test1 : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        Debug.Log("start of time");
        yield return new WaitForSeconds(5f);
        EventBus.SomeAction.Publish();
    }
}
