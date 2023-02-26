using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class, that represents Drag&Drop system for inventory cells.
/// </summary>
//[RequireComponent(typeof)]
public class CellUIMovler : MonoBehaviour
{
    [SerializeField] private Button _confirmation;
    //[SerializeField] private GameObject _container;

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
        //Collider2D col = Physics2D.OverlapPoint(Input.mousePosition);
        List<Collider2D> results = new List<Collider2D>();
        Collider2D collider = new Collider2D();
        bool foundCollider = false;
        Physics2D.OverlapPoint(Input.mousePosition, new ContactFilter2D().NoFilter(), results);
        results.Remove(this.GetComponent<Collider2D>());
        Debug.Log($"Found {results.Count} colliders");




        foreach (Collider2D col in results)
        {
            if (col.gameObject.GetComponent<Item>() != null)
            {
                collider = col;
                foundCollider = true;
                Debug.Log("Found Item");
                break;
            }
        }

        if (!foundCollider)
        {
            foreach (Collider2D col in results)
            {
                if (col.gameObject.name.StartsWith("EmptyCell"))
                {
                    foundCollider = true;
                    Debug.Log("Found Empty");
                    break;
                }
            }
        }
        
        if (foundCollider)
        {
            this.transform.position = collider.gameObject.transform.position;

            GetComponentInParent<InventoryUI>().Inventory.SwapValuesOfCells(_startIndex, collider.transform.GetSiblingIndex()); // Probably BadPractice.

            int temp = this.transform.GetSiblingIndex();
            this.transform.SetSiblingIndex(collider.transform.GetSiblingIndex());
            collider.transform.SetSiblingIndex(temp);

            Debug.Log("Moved and swaped");
        }
        else
        {
            // Также нужно учесть возврат на ячейку, с которой начиналос движение.
            

            Instantiate(_confirmation, this.transform.parent.parent);
            Debug.Log("conf");

            // Здесь в зависимости от выбора игрока нужно либо:
            // 1) вернуть в исходную позицию this.transform.position = _startPosition;
            // 2) удалить из инвентаря.
        }
    }
}
