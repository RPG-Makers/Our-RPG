using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMechanics : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    private Weapon weapon;

    private void Awake()
    {
        weapon = transform.GetChild(1).gameObject.GetComponent<Weapon>(); // Attention!
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Attack(enemyLayer);
        }
    }
}
