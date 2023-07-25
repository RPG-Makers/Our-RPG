using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arrow : MonoBehaviour
{
    [SerializeField] private int _damage;
    private float _timeToDestroy = 2f;

    private void Awake()
    {
        Destroy(gameObject, _timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDamageable hit))
        {
            hit.GetDamage(_damage);
        }
        // Also here we can add some particle of arrow's destroying.
        Destroy(gameObject);
    }
}
