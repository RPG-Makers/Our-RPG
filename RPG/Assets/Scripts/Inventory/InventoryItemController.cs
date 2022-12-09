using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    private Item item;
    public Button removeButton;

    public void RemoveItem() //удаление предмета в окне инвентаря
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void UseItem() //клик на предмет в окне инвентаря, использование предметов
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                PlayerMovement.Instance.SpeedUp(item.value); //например, зелье немного ускоряет игрока. Сила ускорения задаётся в первичных настройках предмета
               
                break;
            case Item.ItemType.Book:
                //PlayerMovement.Instance.SpeedUp(item.value);
                break;
            case Item.ItemType.Scroll:
                //PlayerMovement.Instance.SpeedUp(item.value);
                break;
        }
        
        RemoveItem(); //удаляем предмет из инвентаря после использования
    }
}