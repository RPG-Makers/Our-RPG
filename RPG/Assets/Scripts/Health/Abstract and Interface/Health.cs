using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] protected PlayerStatisticsData playerStatistics;

    protected abstract void Death();
    public void GetDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Death();
            Destroy(gameObject);
        }
    }
}
