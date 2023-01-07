using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Create new InventoryData")]
public class InventoryData : ScriptableObject
{
    public GameObject template;
    public CellInventory[] cells;
    private void Awake()
    {
        foreach (CellInventory cell in cells)
        {

        }
    }
}
