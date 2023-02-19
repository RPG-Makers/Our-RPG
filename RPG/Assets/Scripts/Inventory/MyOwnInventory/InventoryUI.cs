using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _cellSample;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory(2); // 4!
    }

    private void OnEnable()
    {
        //Debug.Log("Inventory enabled");
        InstantiateInventoryUI();
    }

    public void InstantiateInventoryUI()
    {
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

        foreach (CellInventory cell in _inventory.Cells)
        {
            if (cell.IsEmpty)
            {
                Debug.Log("�����");
                continue;
            }
            else
            {
                Debug.Log("�� �����");
            }
            //if (cell.IsEmpty) continue;

            _cellSample.GetComponentInChildren<Image>().sprite = cell.Item.ItemData.Sprite;
            _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.CurrentAmount);

            Instantiate(_cellSample, this.transform);
            Debug.Log("Instantiated");
        }
        _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = "8"; // What is it?
    }

    //public void GenerateInventoryUI()
    //{
    //    GameObject[] cellsUI = new GameObject[4]; // 4!
    //    int index = 0;




    //    foreach (CellInventory cell in _inventory.Cells)
    //    {
    //        //if (_cellSample.GetComponentInChildren<SpriteRenderer>().sprite == null)
    //        //{
    //        //    Debug.Log("1st empty");
    //        //}
    //        //if (cell.Item.ItemData.Sprite == null)
    //        //{
    //        //    Debug.Log("2nd empty");
    //        //}
    //        _cellSample.GetComponentInChildren<SpriteRenderer>().sprite = cell.Item._itemData.Sprite; //!!!!!!!!!!!!!!
    //        _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = cell.CurrentAmount.ToString();
    //        cellsUI[index] = _cellSample;
    //        Debug.Log("������������ " + index);
    //        index++;
    //    }

    //    foreach (var cell in cellsUI)
    //    {
    //        Instantiate(cell, this.transform);
    //    }
    //}
}
