using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory // Возможно, в этом скрипте имеет смысл использовать не Item, а ItemData.
{
    public CellInventory[] Cells => _cells;

    private CellInventory[] _cells;
    private List<Type> _itemsTypes; // Item types, that we already have in inventory.
                                    //private int _length; // Maybe [SerializeField]?




    private void Init() // !!!!!!!!!!!!!!!!!!!!
    {
        Item.OnTake += TryAdd;
    }

    private void DeInit() // !!!!!!!!!!!!!!!!!!!!
    {
        Item.OnTake -= TryAdd;
    }







    public Inventory(int length)
    {
        if (length <= 0) Debug.LogError("Wrong length of Inventory!");
        else
        {
            _cells = new CellInventory[length];

            // Initialize _cells.
            // Возможно момент инициализации ячейки можно отложить до того момента, когда она понадобится.
            for (int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = new CellInventory();
            }

            _itemsTypes = new List<Type>();
        }
        Init(); // !!!!!!!!!!!!!!!!!!!!
    }

    /// <summary>
    /// Trying to add item in inventory.
    /// </summary>
    private void TryAdd(Item item, out bool added)
    {
        if (!TryChangeAmount(item) && !TryPut(item))
        {
            Debug.LogWarning("There are no space for this item!");
            added = false;
            return;
        }
        _itemsTypes.Add(item.GetType());
        // Deinit().!!!!!!!!!!!!!!!!!!!!!
        //item.Destroy(); Удаление происходит в самом Item по результатам added = false или true.
        //Debug.Log("Предмет добавлен");
        added = true;
    }

    /// <summary>
    /// Trying to change amount of item in existing cell instead of occupation of free cell.
    /// </summary>
    private bool TryChangeAmount(Item item)
    {
        if (item.ItemData.Stackable)
        {
            if (_itemsTypes.Contains(item.GetType()))
            {
                foreach (CellInventory cell in _cells)
                {
                    if (cell.ItemType == item.GetType())
                    {
                        if (!cell.IsFull)
                        {
                            cell.Add(item);
                            //Debug.Log("Changed amount.");
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
            if (cell.ItemType == null)
            {
                cell.Add(item);
                //Debug.Log("Added without changing amount.");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Removes item from inventory.
    /// </summary>
    public void Remove(Item item)
    {
        if (_itemsTypes.Contains(item.GetType()))
        {
            foreach (CellInventory cell in _cells)
            {
                if (cell.ItemType == item.GetType())
                {
                    cell.Subtract();
                    if (cell.IsEmpty) _itemsTypes.Remove(item.GetType());
                    return;
                }
            }
        }
    }

    /// <summary>
    /// Swaps the values of two CellInventory by reference.
    /// </summary>
    /// PUBLIC!!! Probably BadPractice.
    public void SwapValuesOfCells(ref CellInventory firstCell, ref CellInventory secondCell)
    {
        CellInventory temp = firstCell;
        firstCell = secondCell;
        secondCell = temp;
    }

    /// <summary>
    /// Swaps the values of two CellInventory by index.
    /// </summary>
    /// PUBLIC!!! Probably BadPractice.
    public void SwapValuesOfCells(int firstIndex, int secondIndex)
    {
        CellInventory temp = _cells[firstIndex];
        _cells[firstIndex] = _cells[secondIndex];
        _cells[secondIndex] = temp;
    }

    /// <summary>
    /// Returns CellInventory by index.
    /// </summary>
    public CellInventory GetCell(int index)
    {
        return _cells[index];
    }
}
