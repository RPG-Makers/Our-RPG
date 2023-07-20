using System;
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

    private void OnEnable()
    {
        EventBus.EnemyDeath.Subscribe(Handle_EnemyDeath);
        EventBus.SkeletonDeath.Subscribe(Handle_SkeletonDeath);
        EventBus.BoxDeath.Subscribe(Handle_BoxDeath);
    }

    private void OnDisable()
    {
        EventBus.EnemyDeath.Unsubscribe(Handle_EnemyDeath);
        EventBus.SkeletonDeath.Unsubscribe(Handle_SkeletonDeath);
        EventBus.BoxDeath.Unsubscribe(Handle_BoxDeath);
    }

    private void Awake()
    {
        _data = new Dictionary<Type, int>();
    }

    private void Handle_EnemyDeath()
    {
        
    }

    private void Handle_SkeletonDeath()
    {
        
    }

    private void Handle_BoxDeath()
    {
        
    }

    /// <summary>
    /// Detects the death of an entity, that have Health script.
    /// </summary>
    /// <param name="entity">Entity, that died.</param>
    private void Detect(Type entity)
    {
        //Debug.Log("In Detect");
        if (_data.ContainsKey(entity))
        {
            //Debug.Log("Stats already contains " + entity.ToString());
            _data[entity] += 1;

            //int count;
            //_data.TryGetValue(entity, out count);
            //Debug.Log($"Killed {count} {entity}");
        }
        else
        {
            //Debug.Log("Now stats doesn't have " + entity.ToString());
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
