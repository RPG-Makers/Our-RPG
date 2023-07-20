using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    public delegate void OnDeath(Type type);
    public static event OnDeath Notify;
    protected virtual void Death()
    {
        Notify.Invoke(this.GetType());
    }

    public void GetDamage(int damage)
    {
        Debug.Log("Я получил дамаг");
        health -= damage;
        if (health <= 0)
        {
            Death();
            Destroy(gameObject);
        }
    }
}
