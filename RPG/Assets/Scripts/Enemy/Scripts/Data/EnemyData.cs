using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Create new enemy")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public string Description;

    public GameObject EnemyModel;

    public int Health = 20;
    public float Speed = 2f;
    public int Damage = 1;

    public float DetectionDistance; // ��������� ����������� ������. ������������ ������ ��� ������������� ������� ����������. ������ ������������ OnCollisionEnter/Exit.
    public float RunAwayDistance;
}
