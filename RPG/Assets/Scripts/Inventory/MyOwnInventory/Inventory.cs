using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IAddRemove
{
    private List<CellInventory> _cells; // Remake to []
    private int _indexOfFreeCell; // Указатель на полностью свободную ячейку. (Можно проходиться foreach по всем ячейкам и проверять IsFull, но экономнее будет иметь указатель.)
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
        if (_indexOfFreeCell == _cells.Count) // Полностью свободных ячеек нет (но могут быть свободные места в 
        {
            if (!TryChangeAmount(item)) // Если не удалось увеличить количество в какой-либо ячейке.
            {
                Debug.LogWarning("There are no space for this item!");
            }
        }
        else // Свободные ячейки есть.
        {
            if (!TryChangeAmount(item))
            {
                _cells[_indexOfFreeCell].Add(item);
                _indexOfFreeCell++;
            }
        }
    }

    private bool TryChangeAmount(Item item)
    {
        if (item.Stackable) // Если предмет стакается.
        {
            if (_items.Contains(item)) // Если в нашем инветаре уже имеется такой тип вещей, то мы постараемся увеличить имеющееся количество, вместо того, чтобы помещать предмет в свободную ячейку.
            {
                foreach (CellInventory cell in _cells) // Ищем ячейку, в которой содержится наш предмет.
                {
                    if (cell.Item == item) // Нашли ячейку, в котором лежит интересующий нас предмет.
                    {
                        if (!cell.IsFull) // Если ячейка не переполнена.
                        {
                            cell.Add(item);
                            if (cell.IsFull) _indexOfFreeCell++;
                            return true; // Удалось увеличить количество.
                        }
                    }
                }
            }
        }
        // Если дошли до сюда, значит нам не удалось поместить предмет в имеющуюся ячейку (либо предмет не стакается, либо такого предмета нет в инвентаре, либо ячейка с ним переполнена).
        return false;
    }

    void IAddRemove.Remove(Item item)
    {
        if (_indexOfFreeCell == 0) // Инвентарь пуст. (Ну либо логика указателя прописана неверно).
        {
            Debug.LogWarning("Inventory is empty! Nothing to remove.");
        }
        else if (!_items.Contains(item))
        {
            Debug.LogWarning("There are no this type of item in Inventory!");
        }
        else
        {
            // Так ну надо найти где вообще этот предмет лежит. Ну вернее если так посмотреть, то не конкретно этот предмет, а такой тип предмета.

            // А может добавить что-то типа словаря, чтобы каждый раз foreach не запускать?
            // То есть в качестве ключа у нас будет индекс ячейки, а в качестве значения тип предмета в этой ячейке.
            foreach (var cell in _cells)
            {

            }
        }
    }
}
