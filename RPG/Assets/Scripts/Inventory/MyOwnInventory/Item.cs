using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public abstract class Item : MonoBehaviour, IUsable
{
    [SerializeField] private ItemData _itemData;
    public ItemData ItemData => _itemData;
    //[SerializeField] public int MaxAmount { get; private set; }

    //[SerializeField] private string _name;
    //[SerializeField] private int _price;
    //[SerializeField] private Sprite _sprite;
    //[SerializeField] private bool _stackable;
    //public string Name => _name;
    //public Sprite Sprite => _sprite;
    //public bool Stackable => _stackable;

    //public Action OnCellInventoryClicked; ???

    public abstract void Use();



    public delegate void ItemHandler(Item item, out bool added);
    public static event ItemHandler OnTake;

    private void OnMouseDown()
    {
        //OldInventory.Instance.Add(this);

        Debug.Log("�� ���� ������");
        if (_takeable)
        {
            Debug.Log("�� ����� ��������");
            // �� ����� ��� ���������, ������� ������
            bool added;
            OnTake.Invoke(this, out added);
            if (added)
            {
                Destroy(gameObject);
            }
            // ����� ����� ������������ ������� "������� - ���������".
            // ��������� ����� � ���, ��� ����� ��������� ������� �����-�� �������, � �������� �������� ��� (��������� �������� �������� �������).
            // ����� ��������� �������� �������� � ���, ���� �� �� �������� �������. ���� ���� - ���������� Item, �� ���� - ��������� ������ ������.

            // ��� � ������� �� ����� �������� ������ �����������))))))))))))))))))))
        }
        Debug.Log("��� � ���");

        //Destroy(gameObject);
    }


    private bool _takeable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _takeable = true;
            Debug.Log("����� ���������");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _takeable = false;
            Debug.Log("�� ����� ���������");
        }
    }
}
