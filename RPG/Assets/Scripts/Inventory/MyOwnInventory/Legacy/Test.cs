using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject template;

    private void Awake()
    {
        template.GetComponentInChildren<TextMeshProUGUI>().text = "wtf";
    }
}
