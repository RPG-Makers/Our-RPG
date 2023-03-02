using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for detecting deaths of different types of environment (enemies, boxes with loot).
/// Works automatically due to Health.Notify.
/// </summary>
public class StatsLogic : MonoBehaviour
{
    //[SerializeField] private StatsData _data;

    private Dictionary<Type, int> _data;

    private void Awake()
    {
        _data = new Dictionary<Type, int>();
        Health.Notify += Detect;
    }

    /// <summary>
    /// Detects the death of an entity, that have Health script.
    /// </summary>
    /// <param name="entity">Entity, that died.</param>
    private void Detect(Type entity)
    {
        //Debug.Log("Сработала функция Detect");
        if (_data.ContainsKey(entity))
        {
            //Debug.Log("Статистика уже содержит " + entity.ToString());
            _data[entity] += 1;

            //int count;
            //_data.TryGetValue(entity, out count);
            //Debug.Log($"Убито {count} {entity}");
        }
        else
        {
            //Debug.Log("Пока что в статистике нет " + entity.ToString());
            _data.Add(entity, 1);
        }
    }

    /// <summary>
    /// Shows all entity types with count of deaths.
    /// </summary>
    private void ShowAllInfo()
    {
        string result = "";
        foreach (var item in _data)
        {
            result += $"{item.Key} {item.Value}\n";
        }
        Debug.Log(result);
    }
}
