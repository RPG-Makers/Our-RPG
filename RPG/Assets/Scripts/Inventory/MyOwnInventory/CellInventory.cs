using UnityEngine;

public class CellInventory
{
    // Public properties.
    public bool IsEmpty => Data.ItemData is null; // or currentAmount == 0?
    
    public bool IsFull => Data.CurrentAmount == maxAmount;
    
    // Data.
    public CellInventoryData Data { get; private set; }

    // Private variables.
    private int maxAmount = 1; // If we will set 0 by start, IsFull will not allow Inventory.cs put an itemBase.

    public CellInventory(CellInventoryData data)
    {
        Data = data;
    }
    
    public void Add(ItemBase itemBase)
    {
        // Вообще-то заполнена ячейка или нет мы должны проверять тут и в инвентаре просто вызывать здешний TryAdd. Но, возможно, так будет затратнее, потому что каждый раз придётся заходить в функцию вместо того, чтобы просто смотреть значение IsFull.
        if (Data.CurrentAmount == 0)
        {
            Init(itemBase); // Initializing values if cell is empty.
        }
        Data.CurrentAmount++;
        //Debug.Log("Добавили");
    }

    private void Init(ItemBase itemBase)
    {
        Data.Type = itemBase.ItemData.Type; // Так как после поднятия мы уничтожаем предмет, то значение itemBase становится null, соответственно и _item становится null.
        Data.ItemData = itemBase.ItemData;
        // Поэтому возникает ошибка. Нужно заменить _item на itemType. UPD: Заменено.
        maxAmount = itemBase.ItemData.MaxAmount;
    }

    private void DeInit()
    {
        Data.ItemData = null;
        // Data.Type = null;
        Data.CurrentAmount = 0;
        //currentAmount = 0; Нужно ли?
        maxAmount = 1; // вот тут кстати у нас IsFull не будет проходить (при maxAmount = 0), потому что
        // в начале current == max и мы никогда не зайдем ни в какую ячейку.
        // Скорее всего, если мы будем проверять, можем ли поместить предмет, в методе ячейки, то такой проблемы не будет. Но опять-таки, столько раз вызывать функцию обосраться дорого.
    }

    public bool DecreaseAmount(int amount)
    {
        bool success = false;
        int difference = Data.CurrentAmount - amount;
        if (difference == 0)
        {
            Data.CurrentAmount -= amount;
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
            Data.CurrentAmount -= amount;
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
