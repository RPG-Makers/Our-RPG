using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Экземпляр объекта
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItemController[]
        InventoryItems; //это нужно для быстрой обработки данных и хранения данных без необходимости повторных запросов

    private void Awake()
    {
        Instance = this; // проверка на дубликат экземпляра
    }

    public void Add(Item item)
    {
        Items.Add(item); //добавление предмета в лист для отображения в окне инвентаря
    }

    public void Remove(Item item)
    {
        Items.Remove(item); //удаление из листа
    }
    
    public void AddQuantity()
    {
        //если в инвентаре уже есть предмет, то увеличивать его количество
    }

    public void ListItems()
    {
        //очищаем инвентарь перед открытием, иначе дублируются предметы
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var removeButton = obj.transform.Find("RemoveButton").GetComponent<Button>();

            itemName.text = item.itemName; //проставляем название предметов и иконки
            itemIcon.sprite = item.icon;

            if (EnableRemove.isOn) //проверяем тоггл удаления предметов из инвентаря
            {
                removeButton.gameObject.SetActive(true); //если тоггл активирован, показываем крестик удаления предмета
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("RemoveButton").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems() //формируем список предметов для отображения в инвентаре после нажатия на кнопку открытия инвентаря
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}