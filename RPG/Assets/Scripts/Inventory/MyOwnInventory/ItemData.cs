using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public int Price;
    public bool Stackable;
    public int MaxAmount;
    public Sprite Sprite;
}
