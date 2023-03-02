using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    public delegate void OnDeath(Type type);
    public static event OnDeath Notify;
    protected virtual void Death()
    {
        Notify.Invoke(this.GetType());
    }

    public void GetDamage(int damage)
    {
        Debug.Log("Я получил дамаг");
        _health -= damage;
        if (_health <= 0)
        {
            Death();
            Destroy(gameObject);
        }
    }
}
