using System;
using UnityEngine;

public class CellInventory
{
    #region API
    public Type ItemType => itemType;
    public ItemData ItemData => itemData;
    public bool IsEmpty => itemType == null; // or currentAmount == 0?
    public int CurrentAmount => currentAmount;
    public bool IsFull => currentAmount == maxAmount;
    #endregion

    private Type itemType;
    private ItemData itemData; // Возможно, плохая практика хранить это. Приходится хранить это, т.к. оригинальный Item (который подобрали) уничтожаем, и соотвественно уничтожаем все его данные.
    private int currentAmount;
    private int maxAmount = 1; // If we will set 0 by start, IsFull will not allow Inventory.cs put an item.

    public void Add(Item item)
    {
        // Вообще-то заполнена ячейка или нет мы должны проверять тут и в инвентаре просто вызывать здешний TryAdd. Но, возможно, так будет затратнее, потому что каждый раз придётся заходить в функцию вместо того, чтобы просто смотреть значение IsFull.
        if (currentAmount == 0)
        {
            Init(item); // Initializing values if cell is empty.
        }
        currentAmount++;
        //Debug.Log("Добавили");
    }

    private void Init(Item item)
    {
        itemType = item.GetType(); // Так как после поднятия мы уничтожаем предмет, то значение item становится null, соответственно и _item становится null.
        itemData = item.ItemData;
        // Поэтому возникает ошибка. Нужно заменить _item на itemType. UPD: Заменено.
        maxAmount = item.ItemData.MaxAmount;
    }

    private void DeInit()
    {
        itemType = null;
        itemData = null;
        //currentAmount = 0; Нужно ли?
        maxAmount = 1; // вот тут кстати у нас IsFull не будет проходить (при maxAmount = 0), потому что
        // в начале current == max и мы никогда не зайдем ни в какую ячейку.
        // Скорее всего, если мы будем проверять, можем ли поместить предмет, в методе ячейки, то такой проблемы не будет. Но опять-таки, столько раз вызывать функцию обосраться дорого.
    }

    public bool DecreaseAmount(int amount)
    {
        bool success = false;
        int difference = currentAmount - amount;
        if (difference == 0)
        {
            currentAmount -= amount;
            success = true;
            DeInit();
            return success;
        }
        else if (difference < 0)
        {
            Debug.LogWarning("Difference is negative!");
            success = false;
            return success;
        }
        else
        {
            currentAmount -= amount;
            success = true;
            return success;
        }
    }

    //public void Subtract() Work not guaranteed.
    //{
    //    if (currentAmount == 0)
    //    {
    //        Debug.LogWarning("Cell is empty! We can't remove something!");
    //    }
    //    else if (currentAmount < 0)
    //    {
    //        Debug.LogWarning("How?????? Negative index");
    //    }
    //    else // currentAmount > 0.
    //    {
    //        currentAmount--;
    //        if (currentAmount == 0) // Deinitializing values if cell is empty.
    //        {
    //            DeInit();
    //        }
    //    }
    //}
}
