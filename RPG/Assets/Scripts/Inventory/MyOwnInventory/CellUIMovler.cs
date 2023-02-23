using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Playables;
using UnityEngine.UI;

/// <summary>
/// Class, that represents Drag&Drop system for inventory cells.
/// </summary>
//[RequireComponent(typeof)]
public class CellUIMovler : MonoBehaviour
{
    [SerializeField] private Button _confirmation;
    [SerializeField] private GameObject _container;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Click()
    {
        //Debug.Log($"�� ���� ������, �� ��� {GetComponentInChildren<TextMeshProUGUI>().text} ���������");
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    public void Drop()
    {
        //Debug.Log(this.transform.position);
        // If collide with underlayer - set on the cell;
        // Else Instantiate(_confirmation, this.transform.parent.parent);

        List<Collider2D> colliders = new List<Collider2D>();
        if (_collider.OverlapCollider(new ContactFilter2D().NoFilter(), colliders) > 0)
        {
            Debug.Log($"������ {colliders.Count} �����������");
            this.transform.position = FindClosestCollider(colliders).gameObject.transform.position;
        }
        else
        {
            Debug.Log("���� �� ������");
        }
    }

    /// <summary>
    /// Finds the closest Collider2D by postition.
    /// </summary>
    /// <param name="colliders"></param>
    /// <returns></returns>
    private Collider2D FindClosestCollider(List<Collider2D> colliders)
    {
        // ��� ���� ������ ��������� ���, �� ������� ����� ������. � ����� ������ ������� � ���, ����� ������� ���������, �� ������� ��������� ������.
        Collider2D bestCollider = new Collider2D();
        foreach (Collider2D collider in colliders)
        {
            if (collider.OverlapPoint(Input.mousePosition))
            {
                bestCollider = collider;
                Debug.Log("�����");
            }
        }
        return bestCollider;
    }
}
