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

    private Vector3 _startPosition;

    //private void Awake()
    //{
    //    _startPosition = this.transform.position;
    //}

    public void Click()
    {
        //Debug.Log($"Ќа мен€ нажали, во мне {GetComponentInChildren<TextMeshProUGUI>().text} предметов");
    }

    public void BeginDrag()
    {
        _startPosition = this.transform.position;
    }

    public void Drag()
    {
        transform.position = Input.mousePosition;
    }

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
        //    // ƒл€ мен€ лучший коллайдер тот, на котором стоит курсор. ¬ итоге задача состоит в том, чтобы вернуть коллайдер, на котором находитс€ курсор.
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

        Collider2D col = Physics2D.OverlapPoint(Input.mousePosition);
        if (col == null)
        {
            Instantiate(_confirmation, this.transform.parent.parent);

            // «десь в зависимости от выбора игрока нужно либо:
            // 1) вернуть в исходную позицию this.transform.position = _startPosition;
            // 2) удалить из инвентар€.
        }
        else
        {
            this.transform.position = col.gameObject.transform.position;
            //Debug.Log($"New position is {col.gameObject.transform.position}.");
        }
    }
}
