using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class Item : MonoBehaviour, IUsable
{
    [SerializeField] private ItemData _itemData;
    public ItemData ItemData => _itemData;

    private bool _takeable;

    //public Action OnCellInventoryClicked; ???

    public abstract void Use();

    public delegate void ItemHandler(Item item, out bool added);
    public static event ItemHandler OnTake;

    private void OnMouseDown()
    {
        //Debug.Log("�� ���� ������");
        if (_takeable)
        {
            //Debug.Log("�� ����� ��������");
            // ���� �� ����� ��� ���������, �� ��������� ������.
            bool added;
            //if (OnTake == null)
            //{
            //    Debug.Log("����� �� ������ �� ��� �������");
            //}
            OnTake.Invoke(this, out added);
            if (added)
            {
                //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Destroy(gameObject);
                return;
            }
            //Debug.LogWarning("�� ������� �������� �������");

            // ����� ����� ������������ ������� "������� - ���������". UPD: ������������.
            // ��������� ����� � ���, ��� ����� ��������� ������� �����-�� �������, � �������� �������� ��� (��������� �������� �������� �������).
            // ����� ��������� �������� �������� � ���, ���� �� �� �������� �������. ���� ���� - ���������� Item, �� ���� - ��������� ������ ������.

            // ��� � ������� �� ����� �������� ������ �����������))))))))))))))))))))
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool added; // Only for test!!!!! Delete after.
        if (collision.gameObject.CompareTag("Player"))
        {

            OnTake.Invoke(this, out added); // Only for test!!!!! Delete after.
            if (added) // Only for test!!!!! Delete after.
            {
                //transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Destroy(gameObject); // Only for test!!!!! Delete after.
            } // Only for test!!!!! Delete after.

            //////_takeable = true; Restore
            ////////Debug.Log("����� ���������"); Restore
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _takeable = false;
            //Debug.Log("�� ����� ���������");
        }
    }

    public void SetItemData(ItemData data)
    {
        _itemData = data;
    }
}
