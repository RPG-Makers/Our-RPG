using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _cellSample;
    [SerializeField] private GameObject _emptyCell;

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
        // Вообще здесь надо продумать. Будем ли мы пересоздавать UI при каждом открытии, или же будем менять UI при каждом подборе предмета.
        #region Test Area
        //[SerializeField] private GameObject[] _itemsPrefabs;
        //foreach (var item in _itemsPrefabs)
        //{
        //    bool success;
        //    _inventory.TryAdd(item.GetComponent<Item>(), out success);
        //}
        #endregion
        // У нас есть инвентарь, который хранит данные о ячейках.
        // На основе этих данных нам нужно создать GameObject'ы, которые будут отображать данные соответствующей ячейки.
        // Для этого у нас есть префаб ячейки, в котором нам нужно изменить данные.

        // Для каждой ячейки нужно получить следующую информацию: Sprite предмета, количество вещей в ячейке.

        InstantiateInventory?.Invoke();

        foreach (CellInventory cell in _inventory.Cells)
        {
            if (!cell.IsEmpty)
            {
                _cellSample.GetComponentInChildren<Image>().sprite = cell.ItemData.Sprite;
                _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.CurrentAmount);
                GameObject temp = Instantiate(_cellSample, this.transform);
                temp.AddComponent(cell.ItemType);
                temp.GetComponent<Item>().SetItemData(cell.ItemData);
                //Debug.Log("Instantiated");
            }
            else
            {
                Instantiate(_emptyCell, this.transform);
                //GameObject empty = new GameObject(string.Empty, typeof(RectTransform)); //Other way: Instantiate(new GameObject(string.Empty, typeof(RectTransform)), this.transform) Creates 2 GO instead of 1. It can be fixed by an Prefab, but I don't want to keep 1 more link in properties.
                //empty.transform.SetParent(this.transform);
                //Debug.Log("Empty Instantiated");
            }
        }
        _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = "8"; // What is it?
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
    //        Debug.Log("Сгенерирован " + index);
    //        index++;
    //    }

    //    foreach (var cell in cellsUI)
    //    {
    //        Instantiate(cell, this.transform);
    //    }
    //}
}
