using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public ItemType Type;
    public int Price;
    public int MaxAmount;
    public bool Stackable => MaxAmount > 1;
    public Sprite Sprite;

    public enum ItemType
    {
        Book,
        Sword
    }
}
