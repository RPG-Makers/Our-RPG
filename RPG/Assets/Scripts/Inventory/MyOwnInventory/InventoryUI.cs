using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _cellSample;
    [SerializeField] private GameObject[] _itemsPrefabs;

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
        // ” нас есть инвентарь, который хранит данные о €чейках.
        // Ќа основе этих данных нам нужно создать GameObject'ы, которые будут отображать данные соответствующей €чейки.
        // ƒл€ этого у нас есть префаб €чейки, в котором нам нужно изменить данные.

        // ƒл€ каждой €чейки нужно получить следующую информацию: Sprite предмета, количество вещей в €чейке.



        // “естова€ область.
        foreach (var item in _itemsPrefabs)
        {
            bool success;
            _inventory.TryAdd(item.GetComponent<Item>(), out success);
        }
        // “естова€ область.

        foreach (CellInventory cell in _inventory.Cells)
        {
            _cellSample.GetComponentInChildren<Image>().sprite = cell.Item.ItemData.Sprite;
            _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.CurrentAmount);

            Instantiate(_cellSample, this.transform);
            Debug.Log("Instantiated");
        }
        _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = "8";
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
    //        Debug.Log("—генерирован " + index);
    //        index++;
    //    }

    //    foreach (var cell in cellsUI)
    //    {
    //        Instantiate(cell, this.transform);
    //    }
    //}
}
