using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationWindow : MonoBehaviour
{
    private GameObject _dropWindow;

    private InventoryUI _inventoryUI;
    private Inventory _inventory;

    private CellUIMovler _UIcell;
    private int _indexOfCell;

    private int _amountToDrop;

    public void InitializeValues(GameObject dropWindow, InventoryUI inventoryUI, Inventory inventory, CellUIMovler cell, int indexOfCell, int amountToDrop)
    {
        _dropWindow = dropWindow;
        _inventoryUI = inventoryUI;
        _inventory = inventory;
        _UIcell = cell;
        _indexOfCell = indexOfCell;
        _amountToDrop = amountToDrop;
    }

    public void Drop()
    {
        if (_inventory.DecreaseAmount(_indexOfCell, Convert.ToInt32(_amountToDrop)))
        {
            Debug.Log("DropedOut successfully");
            _inventoryUI.InstantiateInventoryUI();
            Destroy(_dropWindow);
            Destroy(_UIcell.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.LogWarning("An error occured while dropping an item!");
        }
    }

    public void Close()
    {
        _UIcell.ReturnToStart();

        Destroy(_dropWindow);
        Destroy(this.gameObject);
    }
}
