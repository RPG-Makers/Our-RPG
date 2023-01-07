using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _cellSample;
    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory(4); // 4!
    }

    private void OnEnable()
    {
        Debug.Log("Inventory enabled");
        GenerateInventoryUI();
    }

    public void GenerateInventoryUI()
    {
        GameObject[] cellsUI = new GameObject[4]; // 4!
        int index = 0;
        foreach (CellInventory cell in _inventory.Cells)
        {
            _cellSample.GetComponentInChildren<SpriteRenderer>().sprite = cell.Item.Sprite;
            _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = cell.CurrentAmount.ToString();
            cellsUI[index] = _cellSample;
            Debug.Log("—генерирован " + index);
            index++;
        }
    }
}
