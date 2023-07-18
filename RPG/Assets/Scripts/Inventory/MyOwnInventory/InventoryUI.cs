using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject cellSample;
    [SerializeField] private GameObject emptyCell;

    // public static Action InstantiateInventory;

    public Inventory Inventory { get; private set; }

//test
    [SerializeField] private InventoryData data;
//test

    private void Awake()
    {
        Inventory = new Inventory(data);
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

        // InstantiateInventory?.Invoke();

        foreach (CellInventory cell in Inventory.Cells)
        {
            if (!cell.IsEmpty)
            {
                cellSample.GetComponentInChildren<Image>().sprite = cell.Data.ItemData.Sprite;
                cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.Data.CurrentAmount);
                GameObject temp = Instantiate(cellSample, this.transform);
                switch (cell.Data.Type)
                {
                    case ItemData.ItemType.Book:
                        temp.AddComponent<IntelligenceBook>();
                        break;
                    case ItemData.ItemType.Sword:
                        temp.AddComponent<Sword>();
                        break;
                    default:
                        throw new ArgumentException("Unknown type of item.");
                }
                temp.GetComponent<Item>().SetItemData(cell.Data.ItemData);
                //Debug.Log("Instantiated");
            }
            else
            {
                Debug.Log("I'm empty");
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
    //        Debug.Log("Сгенерирован " + index);
    //        index++;
    //    }

    //    foreach (var cell in cellsUI)
    //    {
    //        Instantiate(cell, this.transform);
    //    }
    //}
}
