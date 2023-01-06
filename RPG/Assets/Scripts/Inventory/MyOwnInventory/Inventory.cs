using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField] private int _length;

    private CellInventory[] _cells;
    private List<Item> _items; // Item types, that we already have in inventory.

    public Inventory()
    {
        if (_length <= 0) Debug.LogError("Wrong length of Inventory!");
        else
        {
            _cells = new CellInventory[_length];
            _items = new List<Item>();
        }
    }

    public bool TryAdd(Item item)
    {
        if (!TryChangeAmount(item) && !TryPut(item))
        {
            Debug.LogWarning("There are no space for this item!");
            return false;
        }
        _items.Add(item);
        return true;
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

    /// <summary>
    /// Trying to change amount of item in existing cell instead of occupation of free cell.
    /// </summary>
    private bool TryChangeAmount(Item item)
    {
        if (item.Stackable)
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
