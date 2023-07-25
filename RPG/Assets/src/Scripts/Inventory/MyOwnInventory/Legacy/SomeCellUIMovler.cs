using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Playables;
using UnityEngine.UI;

/// <summary>
/// Class, that represents Drag&Drop system for inventory cells.
/// </summary>
//[RequireComponent(typeof)]
public class SomeCellUIMovler : MonoBehaviour
{
    [SerializeField] private Button _confirmation;
    [SerializeField] private GameObject _container;

    private Vector3 _startPosition;
    private int _startIndex;

    //private void Awake()
    //{
    //    _startPosition = this.transform.position;
    //}

    public void Click()
    {
        //Debug.Log($"На меня нажали, во мне {GetComponentInChildren<TextMeshProUGUI>().text} предметов");
    }

    public void BeginDrag()
    {
        _startPosition = this.transform.position;
        _startIndex = this.transform.GetSiblingIndex();
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

    //!!! А что, если мы перетащим на непустую ячейку???
    public void Drop()
    {
        #region Introduce (Probably legacy, coz another logic)
        // If collide with underlayer - set on the cell;
        // Else Instantiate(_confirmation, this.transform.parent.parent);

        // There are two ways to solve this task.
        // 1st (simple) is use Physics2D.OverlapPoint(Input.mousePosition).
        // 2nd (a little bit difficult, but also simple, but not in 1 string) is use OverlapCollider(...).
        #endregion
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
        //    // Для меня лучший коллайдер тот, на котором стоит курсор. В итоге задача состоит в том, чтобы вернуть коллайдер, на котором находится курсор.
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
        #region 2nd
        List<Collider2D> results = new List<Collider2D>();
        Collider2D collider = new Collider2D();
        bool found = false;
        bool needSwap = false;
        Vector3 NewPosition = this.transform.position;

        Physics2D.OverlapPoint(Input.mousePosition, new ContactFilter2D().NoFilter(), results);
        Debug.Log($"Found {results.Count} colliders");

        if (results.Count == 2)
        {
            collider = results[1];
            if (collider.transform.position == this.transform.position) // This IF guarantees, that our UI Cell will change position.
            {
                collider = results[0];
            }
            found = true;
            needSwap = true;
            NewPosition = collider.transform.position;
            Debug.Log("Not empty collider");
        }
        else if (results.Count == 1) // This ELSE IF is works when we are moving UI Cell on the same Cell (Drag from 1st and drop to 1st).
        {
            found = true;
            Debug.Log("Returned to start");
            #region old
            //collider = results[0];
            //found = true;
            //Debug.Log("One!");
            #endregion
        }
        else
        {
            Debug.Log("Empty collider");
        }
        //if (results.Count > 2)
        //{
        //    col = results[1];
        //}
        //else
        //{
        //    col = results[1];
        //}


        if (found)
        {
            this.transform.position = NewPosition;

            // Swapping Cells like part of Inventory.

            if (needSwap) GetComponentInParent<InventoryUI>().Inventory.SwapValuesOfCells(_startIndex, collider.transform.GetSiblingIndex()); // Probably BadPractice.

            // Swapping Cells like part of UI.

            int temp = this.transform.GetSiblingIndex();
            this.transform.SetSiblingIndex(collider.transform.GetSiblingIndex());
            collider.transform.SetSiblingIndex(temp);
        }
        else
        {
            Instantiate(_confirmation, this.transform.parent.parent);

            // Здесь в зависимости от выбора игрока нужно либо:
            // 1) вернуть в исходную позицию this.transform.position = _startPosition;
            // 2) удалить из инвентаря.
        }
        #endregion
    }
}
