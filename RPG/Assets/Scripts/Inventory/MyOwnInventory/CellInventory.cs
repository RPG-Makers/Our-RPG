using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class CellInventory
{
    // Наверное, здесь нужно ранить не список обьъектов, а один объект, который лежит в ячейке. Допустим, у нас лежит какой-то ингридиент, который может стакаться.
    // Какой смысл хранить список этого предмета? По сути это ведь один и тот же предмет, который ничем не отличается. В итоге мы просто будет уменьшать имееющееся значение, пока можем.
    public Item Item => _item;
    public bool IsFull => _currentAmount == _maxAmount;
    public bool IsEmpty => _currentAmount == 0;

    private Item _item;
    private int _currentAmount;
    private int _maxAmount = 1; // If we will set 0 by start, IsFull will not allow Inventory.cs put an item.

    public void Add(Item item)
    {
        // Вообще-то заполнена ячейка или нет мы должны проверять тут и в инвентаре просто вызывать здешний TryAdd. Но, возможно, так будет затратнее, потому что каждый раз придётся заходить в функцию вместо того, чтобы просто смотреть значение IsFull.
        if (_currentAmount == 0)
        {
            Init(item); // Initializing values if cell is empty.
            _currentAmount++;
        }
        _currentAmount++;
    }

    private void Init(Item item)
    {
        _item = item;
        _maxAmount = item.MaxAmount;
    }

    private void DeInit()
    {
        _item = null;
        _maxAmount = 0; // вот тут кстати у нас IsFull не будет проходить, потому что
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
                _item = null;
                _maxAmount = 0;
            }
        }
    }
}
