using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/InventoryData")]
public class InventoryData : ScriptableObject
{
    public CellInventory[] cells;
    private void Awake()
    {
        foreach (CellInventory cell in cells)
        {

        }
    }
}
