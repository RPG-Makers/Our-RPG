using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class CellInventory
{
    #region API
    public Type ItemType => _itemType;
    public ItemData ItemData => _itemData;
    public bool IsEmpty => _itemType == null; // or _currentAmount == 0?
    public int CurrentAmount => _currentAmount;
    public bool IsFull => _currentAmount == _maxAmount;
    #endregion

    private Type _itemType;
    private ItemData _itemData; // Возможно, плохая практика хранить это. Приходится хранить это, т.к. оригинальный Item (который подобрали) уничтожаем, и соотвественно уничтожаем все его данные.
    private int _currentAmount;
    private int _maxAmount = 1; // If we will set 0 by start, IsFull will not allow Inventory.cs put an item.

    public void Add(Item item)
    {
        // Вообще-то заполнена ячейка или нет мы должны проверять тут и в инвентаре просто вызывать здешний TryAdd. Но, возможно, так будет затратнее, потому что каждый раз придётся заходить в функцию вместо того, чтобы просто смотреть значение IsFull.
        if (_currentAmount == 0)
        {
            Init(item); // Initializing values if cell is empty.
        }
        _currentAmount++;
        //Debug.Log("Добавили");
    }

    private void Init(Item item)
    {
        _itemType = item.GetType(); // Так как после поднятия мы уничтожаем предмет, то значение item становится null, соответственно и _item становится null.
        _itemData = item.ItemData;
        // Поэтому возникает ошибка. Нужно заменить _item на _itemType. UPD: Заменено.
        _maxAmount = item.ItemData.MaxAmount;
    }

    private void DeInit()
    {
        _itemType = null;
        _itemData = null;
        //_currentAmount = 0; Нужно ли?
        _maxAmount = 1; // вот тут кстати у нас IsFull не будет проходить (при _maxAmount = 0), потому что
        // в начале current == max и мы никогда не зайдем ни в какую ячейку.
        // Скорее всего, если мы будем проверять, можем ли поместить предмет, в методе ячейки, то такой проблемы не будет. Но опять-таки, столько раз вызывать функцию обосраться дорого.
    }

    public void Subtract()
    {
        if (_currentAmount == 0)
        {
            Debug.LogWarning("Cell is empty! We can't remove something!");
        }
        else if (_currentAmount < 0)
        {
            Debug.LogWarning("How?????? Negative index");
        }
        else // _currentAmount > 0.
        {
            _currentAmount--;
            if (_currentAmount == 0) // Deinitializing values if cell is empty.
            {
                DeInit();
            }
        }
    }
}
