using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMechanics : MonoBehaviour
{
    [SerializeField] private WeaponStats weapon;
    [SerializeField] private GameObject weaponGo;
    [SerializeField] private LayerMask enemyLayer;
    private Animator weaponAnimator;
    private Transform weaponTransform;

    private void Awake()
    {
        weaponAnimator = weaponGo.GetComponent<Animator>();
        weaponTransform = weaponGo.transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponAnimator.Play("smth");
            Physics2D.OverlapCircle(weaponTransform.position, 1f, enemyLayer)?.gameObject.GetComponent<Health>().getHit(weapon.damage); // I'm really don't understanding, why it doesn't work if we are using same Vector2.
        }
    }
}
