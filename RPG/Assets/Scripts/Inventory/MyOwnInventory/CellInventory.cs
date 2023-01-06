using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class CellInventory
{
    // Наверное, здесь нужно ранить не список обьъектов, а один объект, который лежит в ячейке. Допустим, у нас лежит какой-то ингридиент, который может стакаться.
    // Какой смысл хранить список этого предмета? По сути это ведь один и тот же предмет, который ничем не отличается. В итоге мы просто будет уменьшать имееющееся значение, пока можем.
    public Item Item => _item;
    public bool IsFull => _isFull;
    public bool IsEmpty => _currentAmount == 0;

    private Item _item;
    private bool _isFull;
    private int _currentAmount;
    private int _maxAmount;

    public void Add(Item item)
    {
        // Вообще-то заполнена ячейка или нет мы должны проверять тут и в инвентаре просто вызывать здешний TryAdd. Но, возможно, так будет затратнее, потому что каждый раз придётся заходить в функцию вместо того, чтобы просто смотреть значение IsFull.
        if (_currentAmount == 0) Init(item); // Initializing values if cell is empty.
        else if (_currentAmount == _maxAmount) // Cell is full.
        {
            Debug.LogWarning("Cell is full");
            // need to go next cell; !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Ну здесь наверное надо проверить, остались ли свободные ячейки в инвентаре. Если да - калдём туда, если нет - то инвентарь заполнен, до скорых встреч.
            return;
        }
        else // Probably we have some space.
        {
            _currentAmount++;
            if (_currentAmount == _maxAmount) _isFull = true;
        }
    }

    private void Init(Item item)
    {
        _item = item;
        _maxAmount = item.MaxAmount;
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
            _isFull = false;
            if (_currentAmount == 0) // Deinitializing values if cell is empty.
            {
                _item = null;
                _maxAmount = 0;
            }
        }
    }
}
