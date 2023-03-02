using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBow : Weapon
{
    [SerializeField] private BowData _bowData;

    [SerializeField] private Transform _spawnParent;

    private Transform _arrowSpawnPoint;

    private void Awake()
    {
        _arrowSpawnPoint = transform.GetChild(0).transform;
    }
    public override void Attack(LayerMask enemyLayer)
    {
        Debug.Log("Bow Attack");
        GameObject launchedArrow = Instantiate(_bowData.arrow, _arrowSpawnPoint.position, _arrowSpawnPoint.rotation, _spawnParent);
        //launchedArrow.GetComponent<Arrow>().SetDamage((weaponData as BowData).Damage);
        launchedArrow.GetComponent<Rigidbody2D>().AddForce(transform.up * 300);
    }
}
