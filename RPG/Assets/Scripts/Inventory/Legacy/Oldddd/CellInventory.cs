using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OldCellInventory : MonoBehaviour
{
    public Button removeButton;

    private Item _item;

    //public Action OnCellInventoryClick;
    public void RemoveItem() //удаление предмета в окне инвентаря
    {
        OldInventory.Instance.Remove(_item);
        Destroy(gameObject);
    }

    public void AddItem(Item item)
    {
        _item = item;
    }

    private void OnMouseDown()
    {
        (_item as IUsable).Use();
    }

    //public void UseItem() //клик на предмет в окне инвентаря, использование предметов
    //{
    //    switch (item.itemType)
    //    {
    //        case Item.ItemType.Potion:
    //            PlayerMovement.Instance.SpeedUp(item.value); //например, зелье немного ускоряет игрока. Сила ускорения задаётся в первичных настройках предмета

    //            break;
    //        case Item.ItemType.Book:
    //            //PlayerMovement.Instance.SpeedUp(item.value);
    //            break;
    //        case Item.ItemType.Scroll:
    //            //PlayerMovement.Instance.SpeedUp(item.value);
    //            break;
    //    }

    //    RemoveItem(); //удаляем предмет из инвентаря после использования
    //}
}