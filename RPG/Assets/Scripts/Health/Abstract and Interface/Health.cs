using UnityEngine;

public abstract class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    protected abstract void Death();

    public void GetDamage(int damage)
    {
        Debug.Log("I got damage.");
        health -= damage;
        if (health <= 0)
        {
            Death();
            Destroy(gameObject);
        }
    }
}
