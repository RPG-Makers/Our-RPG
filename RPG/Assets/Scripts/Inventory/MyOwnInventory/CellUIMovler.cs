using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class, that represents Drag&Drop system for inventory cells.
/// </summary>
//[RequireComponent(typeof)]
public class CellUIMovler : MonoBehaviour
{
    [SerializeField] private GameObject _emptyCell;
    [SerializeField] private GameObject _dropWindow;

    private GameObject _replacement;

    private Vector3 _startPosition;
    private int _startIndex;
    private Transform _startParent;

    //private void Awake()
    //{
    //    _startPosition = this.transform.position;
    //}

    public void Click()
    {
        //Debug.Log($"�� ���� ������, �� ��� {GetComponentInChildren<TextMeshProUGUI>().text} ���������");
    }

    public void BeginDrag()
    {
        _startPosition = this.transform.position;
        _startIndex = this.transform.GetSiblingIndex();
        _startParent = this.transform.parent;

        int temp = this.transform.GetSiblingIndex();
        _replacement = Instantiate(_emptyCell, this.transform.parent);
        _replacement.transform.SetSiblingIndex(temp);
        _replacement.name = "repla";
        // ������ �� ����� ������ ��������� ��������, ������� ������� �� ���� ��� �������� �� �� �� ������.

        // �������� ������ "���������", ��������� ����� ����� ���������� ������ ���� ��������� �����.

        // �������� ��������� �������� ������ �� �������� ������ ��� �����.

        this.transform.SetParent(this.transform.parent.parent);
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    //!!! � ���, ���� �� ��������� �� �������� ������???
    public void Drop()
    {
        // If collide with underlayer - set on the cell;
        // Else Instantiate(_confirmation, this.transform.parent.parent);

        // There are two ways to solve this task.
        // 1st (simple) is use Physics2D.OverlapPoint(Input.mousePosition).
        // 2nd (a little bit difficult, but also simple, but not in 1 string) is use OverlapCollider(...).

        #region 1st
        // private Collider2D _collider;
        // _collider = GetComponent<Collider2D>();
        //List<Collider2D> colliders = new List<Collider2D>();
        //if (_collider.OverlapCollider(new ContactFilter2D().NoFilter(), colliders) > 0)
        //{
        //    Debug.Log($"Overlaped {colliders.Count} colliders.");
        //    this.transform.position = FindClosestCollider(colliders).gameObject.transform.position;
        //}
        ///// <summary>
        ///// Finds the closest Collider2D by postition.
        ///// </summary>
        ///// <param name="colliders">Input colliders</param>
        ///// <returns>Closest collider</returns>
        //private Collider2D FindClosestCollider(List<Collider2D> colliders)
        //{
        //    // ��� ���� ������ ��������� ���, �� ������� ����� ������. � ����� ������ ������� � ���, ����� ������� ���������, �� ������� ��������� ������.
        //    Collider2D bestCollider = new Collider2D();
        //    foreach (Collider2D collider in colliders)
        //    {
        //        if (collider.OverlapPoint(Input.mousePosition))
        //        {
        //            bestCollider = collider;
        //            // break???
        //        }
        //    }
        //    return bestCollider;
        //}
        //else Debug.Log("Nothing overlaped.");
        #endregion
        //Collider2D col = Physics2D.OverlapPoint(Input.mousePosition);
        List<Collider2D> results = new List<Collider2D>();
        Collider2D collider = new Collider2D();
        bool foundCollider = false;
        int indexCollider = -1;
        Physics2D.OverlapPoint(Input.mousePosition, new ContactFilter2D().NoFilter(), results);
        results.Remove(this.GetComponent<Collider2D>());
        //Debug.Log($"Found {results.Count} colliders");

        foreach (Collider2D col in results)
        {
            if (col.gameObject.GetComponent<Item>() != null)
            {
                collider = col;
                foundCollider = true;
                indexCollider = collider.transform.GetSiblingIndex();
                //Debug.Log("Found Item");
                break;
            }
        }

        if (!foundCollider)
        {
            foreach (Collider2D col in results)
            {
                if (col.gameObject.name.StartsWith("EmptyCell"))
                {
                    collider = col;
                    foundCollider = true;
                    indexCollider = collider.transform.GetSiblingIndex();
                    //Debug.Log("Found Empty");
                    break;
                }
            }
        }
        
        if (foundCollider)
        {
            this.transform.position = collider.gameObject.transform.position;
            Destroy(_replacement);
            this.transform.SetParent(collider.transform.parent);
            this.transform.SetSiblingIndex(_startIndex);

            GetComponentInParent<InventoryUI>().Inventory.SwapValuesOfCells(_startIndex, indexCollider); // Probably BadPractice.

            int temp = this.transform.GetSiblingIndex();
            this.transform.SetSiblingIndex(collider.transform.GetSiblingIndex());
            collider.transform.SetSiblingIndex(temp);

            Debug.Log("Moved and swaped");
        }
        else
        {
            // ����� ����� ������ ������� �� ������, � ������� ���������� ��������.

            GameObject dropWindow = Instantiate(_dropWindow, this.transform.parent.parent);

            dropWindow.GetComponent<DropWindow>().InitializeValues(_startIndex, this);

            // ����� � ����������� �� ������ ������ ����� ����:
            // 1) ������� � �������� ������� this.transform.position = _startPosition;
            // 2) ������� �� ���������.
        }
    }

    public void ReturnToStart()
    {
        this.transform.position = _startPosition;
        Destroy(_replacement);
        this.transform.SetParent(_startParent);
        this.transform.SetSiblingIndex(_startIndex);
    }
}
