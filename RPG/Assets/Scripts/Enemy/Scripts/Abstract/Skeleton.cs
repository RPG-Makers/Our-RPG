using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkeletonHealth))]
public abstract class Skeleton : EnemyBase
{
    private void Update() // ��� ������������� � ����������� ����� �������������� Update() (override or new) ��� �������� ���������� ������ ��� �����.
    {
        Debug.Log("Skeleton is doing something interesting");
    }
}