using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;

    void Pickup() //клик на предмет для поднятия в инвентарь
    {
        //доработать проверку на уже существующий предмет в инвентаре, чтобы стакались:  before clicking on the items, if there is the same item in the list of added items, you can only increase the number.
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject); //удаляем поднятый предмет со сцены, мы увидим его в окне инвентаря
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
