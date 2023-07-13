using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject cellSample;
    [SerializeField] private GameObject emptyCell;

    public static Action InstantiateInventory;

    private Inventory _inventory;
    public Inventory Inventory => _inventory; // Probably BadPractice.

    private void Awake()
    {
        _inventory = new Inventory(9);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //Debug.Log("Inventory enabled");
        InstantiateInventoryUI();
    }

    public void InstantiateInventoryUI()
    {
        Clear();
        // ������ ����� ���� ���������. ����� �� �� ������������� UI ��� ������ ��������, ��� �� ����� ������ UI ��� ������ ������� ��������.
        #region Test Area
        //[SerializeField] private GameObject[] _itemsPrefabs;
        //foreach (var item in _itemsPrefabs)
        //{
        //    bool success;
        //    _inventory.TryAdd(item.GetComponent<Item>(), out success);
        //}
        #endregion
        // � ��� ���� ���������, ������� ������ ������ � �������.
        // �� ������ ���� ������ ��� ����� ������� GameObject'�, ������� ����� ���������� ������ ��������������� ������.
        // ��� ����� � ��� ���� ������ ������, � ������� ��� ����� �������� ������.

        // ��� ������ ������ ����� �������� ��������� ����������: Sprite ��������, ���������� ����� � ������.

        InstantiateInventory?.Invoke();

        foreach (CellInventory cell in _inventory.Cells)
        {
            if (!cell.IsEmpty)
            {
                cellSample.GetComponentInChildren<Image>().sprite = cell.ItemData.Sprite;
                cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.CurrentAmount);
                GameObject temp = Instantiate(cellSample, this.transform);
                temp.AddComponent(cell.ItemType);
                temp.GetComponent<Item>().SetItemData(cell.ItemData);
                //Debug.Log("Instantiated");
            }
            else
            {
                Instantiate(emptyCell, this.transform);
                //GameObject empty = new GameObject(string.Empty, typeof(RectTransform)); //Other way: Instantiate(new GameObject(string.Empty, typeof(RectTransform)), this.transform) Creates 2 GO instead of 1. It can be fixed by an Prefab, but I don't want to keep 1 more link in properties.
                //empty.transform.SetParent(this.transform);
                //Debug.Log("Empty Instantiated");
            }
        }
        cellSample.GetComponentInChildren<TextMeshProUGUI>().text = "8"; // What is it?
    }

    /// <summary>
    /// Clears all inventory UI.
    /// </summary>
    /// make private!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public void Clear()
    {
        Transform[] children = GetComponentsInChildren<Transform>();

        // Starting from 1 to avoid self deleting.
        for (int i = 1; i < children.Length; i++)
        {
            Destroy(children[i].gameObject);
        }
    }

    //public void GenerateInventoryUI()
    //{
    //    GameObject[] cellsUI = new GameObject[4]; // 4!
    //    int index = 0;




    //    foreach (CellInventory cell in _inventory.Cells)
    //    {
    //        //if (cellSample.GetComponentInChildren<SpriteRenderer>().sprite == null)
    //        //{
    //        //    Debug.Log("1st empty");
    //        //}
    //        //if (cell.Item.ItemData.Sprite == null)
    //        //{
    //        //    Debug.Log("2nd empty");
    //        //}
    //        cellSample.GetComponentInChildren<SpriteRenderer>().sprite = cell.Item._itemData.Sprite; //!!!!!!!!!!!!!!
    //        cellSample.GetComponentInChildren<TextMeshProUGUI>().text = cell.CurrentAmount.ToString();
    //        cellsUI[index] = cellSample;
    //        Debug.Log("������������ " + index);
    //        index++;
    //    }

    //    foreach (var cell in cellsUI)
    //    {
    //        Instantiate(cell, this.transform);
    //    }
    //}
}
