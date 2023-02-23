using TMPro;
using UnityEngine;

/// <summary>
/// Class, that represents Drag&Drop system for inventory cells.
/// </summary>
public class CellUIMovler : MonoBehaviour
{
    public void Click()
    {
        Debug.Log($"�� ���� ������, �� ��� {GetComponentInChildren<TextMeshProUGUI>().text} ���������");
    }
}
