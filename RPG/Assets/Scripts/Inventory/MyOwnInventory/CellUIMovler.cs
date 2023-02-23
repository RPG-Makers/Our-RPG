using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class, that represents Drag&Drop system for inventory cells.
/// </summary>
public class CellUIMovler : MonoBehaviour
{
    [SerializeField] private Button _confirmation;
    [SerializeField] private GameObject _container;
    Collider2D _someCol;

    public void Click()
    {
        Debug.Log($"�� ���� ������, �� ��� {GetComponentInChildren<TextMeshProUGUI>().text} ���������");
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    public void Drop()
    {
        Debug.Log(this.transform.position);
        Instantiate(_confirmation, this.transform.parent.parent);
    }
}
