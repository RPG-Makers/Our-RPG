using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMeeleBase : EnemyBase
{
    private SwordData SwordData { get; set; }

    private void Update()
    {
        if (_target != null)
        {
            // ����� ���������, ���� ���������� ������, �� ���������, ����� ���������.
            if (Vector3.Distance(this.transform.position, _target.transform.position) <= _weaponData.Distance)
            {
                // ����� ��������� �������� �����.
                if (_weaponData.Cooldown <= 0)
                {

                }
                MeeleAttack();
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _enemyData.Speed);
            }
        }
    }

    private void MeeleAttack()
    {
        _isAttacking = true;
        Debug.Log("Enemy is melee attacking.");
    }
}
