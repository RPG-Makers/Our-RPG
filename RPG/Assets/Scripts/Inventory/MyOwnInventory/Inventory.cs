using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IAddRemove
{
    private List<CellInventory> _cells;
    private int _indexOfFreeCell; // Можно проходиться foreach по всем ячейкам и проверять IsFull, но экономнее будет иметь указатель.
    private List<Item> _items; // Item types, that we already have in inventory.

    public Inventory()
    {
        _cells = new List<CellInventory>();
        _indexOfFreeCell = 0; //  By default the inventory is clear. That's why 0.
    }


    void IAddRemove.Add(Item item)
    {
        // Для начала здесь можем проверить, есть ли место в инвентаре. То есть для стакающихся есть ли слоты для увеличения, а для нестакающихся свободная ячейка.
        // То есть проверить, можем ли мы вообще поместить этот предмет в инвентарь.
        CellInventory cellInventory;
        if (_indexOfFreeCell == _cells.Count) // Полностью свободных ячеек нет.
        {
            // Возможно удастся увеличить количество (в ячейке).
            if (CanChangeAmount(item, out cellInventory))
            {
                cellInventory.Add(item);
                if (cellInventory.IsFull) _indexOfFreeCell++;
                return;
            }
            else
            {
                Debug.LogWarning("There are no space for this item!");
            }
        }
        else // Свободные ячейки есть.
        {
            if (CanChangeAmount(item, out cellInventory))
            {
                cellInventory.Add(item);
                if (cellInventory.IsFull) _indexOfFreeCell++;
            }
            else
            {
                _cells[_indexOfFreeCell].Add(item);
                if (cellInventory.IsFull) _indexOfFreeCell++;
            }
        }



        //CellInventory cellInventory;
        
        



        //// Вообще здесь нам нужно проверить, имеется ли такой предмет в инвентаре. Потому что если, например, это тот предмет, который стакается,
        //// то нам нужно положить этот предмет в уже имеющуюся ячейку.
        //if (_indexOfFreeCell == _cells.Count) // Inventory is full. Вообще сначала нужно првоерить, можем ли мы поместить предмет не в новую ячейку, а в уже существующую с увеличением количества.
        //{
        //    Debug.LogWarning("Inventory is full!");
        //    return;
        //}
        //_cells[_indexOfFreeCell].Add(item);
        //_indexOfFreeCell++;
    }

    private bool CanChangeAmount(Item item, out CellInventory IncreaseCell)
    {
        if (item.Stackable) // Если предмет стакается.
        {
            if (_items.Contains(item)) // Если в нашем инветаре уже имеется такой тип вещей, то мы постараемся увеличить имеющееся количество, вместо того, чтобы помещать предмет в свободную ячейку.
            {
                foreach (CellInventory cell in _cells) // Ищем ячейку, в котором содержится наш предмет.
                {
                    if (cell.Item == item) // Нашли ячейку, в котором лежит интересующий нас предмет.
                    {
                        if (!cell.IsFull) // Если ячейка не переполнена.
                        {
                            cell.Add(item);
                            IncreaseCell = cell;
                            return true; // Удалось увеличить количество.
                        }
                    }
                    // Если дошли до сюда (нет, не до сюда, это неверно), значит нам не удалось поместить предмет в имеющуюся ячейку (либо такого предмета нет, либо ячейка с ним переполнена).
                    // Здесь нужно добавить этот предмет в новую ячейку. !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    // А мб здесь не нужно, потому что у нас есть конструкции снизу, подумать.
                }
                // Если мы дошли до этой строчки, значит нам не удалось увеличить количество. Придётся помещать предмет в новую ячейку.
                IncreaseCell = null;
                return false;
            }
            else // Такого предмета ещё нет в инвентаре.
            {
                IncreaseCell = null;
                return false;
            }
        }
        else // Не стакается.
        {
            IncreaseCell = null;
            return false;
        }
    }

    void IAddRemove.Remove(Item item)
    {
        
    }
}
