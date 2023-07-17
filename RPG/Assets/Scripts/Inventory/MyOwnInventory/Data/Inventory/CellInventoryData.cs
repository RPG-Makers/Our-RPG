using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CellInventoryData", menuName = "Inventory/CellInventoryData")]
public class CellInventoryData : ScriptableObject
{
    public ItemData ItemData;
    public Type ItemType;
    public int CurrentAmount;
}
