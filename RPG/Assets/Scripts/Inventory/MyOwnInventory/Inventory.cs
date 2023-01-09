using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour // Возможно, в этом скрипте имеет смысл использовать не Item, а ItemData.
{
    public CellInventory[] Cells => _cells;

    private CellInventory[] _cells;
    private List<Item> _items; // Item types, that we already have in inventory.
    //private int _length; // Maybe [SerializeField]?



    
    private void OnEnable()
    {
        Item.OnTake += TryAdd;
    }

    private void OnDisable()
    {
        Item.OnTake -= TryAdd;
    }







    public Inventory(int length)
    {
        if (length <= 0) Debug.LogError("Wrong length of Inventory!");
        else
        {
            _cells = new CellInventory[length];
            _items = new List<Item>();
        }
    }

    public bool TryAdd(Item item)
    {
        Debug.Log("In TryAdd");
        if (!TryChangeAmount(item) && !TryPut(item))
        {
            Debug.LogWarning("There are no space for this item!");
            return false;
        }
        _items.Add(item);
        Destroy(item);
        Debug.Log("Предмет уничтожен");
        return true;
    }

    /// <summary>
    /// Trying to change amount of item in existing cell instead of occupation of free cell.
    /// </summary>
    private bool TryChangeAmount(Item item)
    {
        if (item.ItemData.Stackable)
        {
            if (_items.Contains(item))
            {
                foreach (CellInventory cell in _cells)
                {
                    if (cell.Item == item)
                    {
                        if (!cell.IsFull)
                        {
                            cell.Add(item);
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Trying to find free cell in inventory and put an Item there.
    /// </summary>
    private bool TryPut(Item item)
    {
        foreach (var cell in _cells)
        {
            if (cell.Item == null)
            {
                cell.Add(item);
                return true;
            }
        }
        return false;
    }

    public void Remove(Item item)
    {
        if (_items.Contains(item))
        {
            foreach (CellInventory cell in _cells)
            {
                if (cell.Item == item)
                {
                    cell.Subtract();
                    if (cell.IsEmpty) _items.Remove(item);
                }
            }
        }
    }
}
