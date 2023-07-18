using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory // ��������, � ���� ������� ����� ����� ������������ �� Item, � ItemData.
{
    public CellInventory[] Cells { get; }

    private readonly List<Type> itemsTypes; // Item types, that we already have in inventory.
    //private int _length; // Maybe [SerializeField]?
    
    //test
    private InventoryData data;
    //test

    private void Init() // !!!!!!!!!!!!!!!!!!!!
    {
        Item.OnTake += TryAdd;
    }

    private void DeInit() // !!!!!!!!!!!!!!!!!!!!
    {
        Item.OnTake -= TryAdd;
    }

    public Inventory(InventoryData inventoryData)
    {
        CheckInventoryData(inventoryData);

        data = inventoryData;
        Cells = new CellInventory[data.Cells.Length];
        // Initialize cells.
        // �������� ������ ������������� ������ ����� �������� �� ���� �������, ����� ��� �����������.
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i] = new CellInventory(data.Cells[i]);
        }
        itemsTypes = new List<Type>();
        
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
        itemsTypes.Add(item.GetType());
        // Deinit().!!!!!!!!!!!!!!!!!!!!!
        //item.Destroy(); �������� ���������� � ����� Item �� ����������� added = false ��� true.
        //Debug.Log("������� ��������");
        added = true;
    }

    /// <summary>
    /// Trying to change amount of item in existing cell instead of occupation of free cell.
    /// </summary>
    private bool TryChangeAmount(Item item)
    {
        if (item.ItemData.Stackable)
        {
            if (itemsTypes.Contains(item.GetType()))
            {
                foreach (CellInventory cell in Cells)
                {
                    if (cell.Data.Type == item.ItemData.Type)
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
        foreach (var cell in Cells)
        {
            if (cell.Data.Type == null) // just check data is null
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
    //public void Remove(Item item) // Work not guaranteed!
    //{
    //    if (itemsTypes.Contains(item.GetType()))
    //    {
    //        foreach (CellInventory cell in cells)
    //        {
    //            if (cell.ItemType == item.GetType())
    //            {
    //                cell.Subtract();
    //                if (cell.IsEmpty) itemsTypes.Remove(item.GetType());
    //                return;
    //            }
    //        }
    //    }
    //}

    #region Unused Swap
    /// <summary>
    /// Swaps the values of two CellInventory by reference.
    /// </summary>
    /// PUBLIC!!! Probably BadPractice.
    public void SwapValuesOfCells(ref CellInventory firstCell, ref CellInventory secondCell)
    {
        (firstCell, secondCell) = (secondCell, firstCell);
    }
    #endregion

    /// <summary>
    /// Swaps the values of two CellInventory by index.
    /// </summary>
    /// PUBLIC!!! Probably BadPractice.
    public void SwapValuesOfCells(int firstIndex, int secondIndex)
    {
        (Cells[firstIndex], Cells[secondIndex]) = (Cells[secondIndex], Cells[firstIndex]);
        (data.Cells[firstIndex], data.Cells[secondIndex]) = (data.Cells[secondIndex], data.Cells[firstIndex]);
    }

    /// <summary>
    /// Returns CellInventory by index.
    /// </summary>
    public CellInventory GetCell(int index)
    {
        return Cells[index];
    }

    public bool DecreaseAmount(int indexOfCell, int amount)
    {
        return Cells[indexOfCell].DecreaseAmount(amount);
    }

    private void CheckInventoryData(InventoryData inventoryData)
    {
        if (inventoryData.Cells.Length <= 0) throw new ArgumentException("Wrong length of Inventory!");
    }
}
