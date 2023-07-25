using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string EnemyName;
    public string Description;

    public GameObject EnemyModel;

    public int Health = 20;
    public float Speed = 2f;
    public int Damage = 1;

    public float DetectionDistance; // Дальность обнаружения игрока. Используется только для инициализации радиуса коллайдера. Дальше отрабатывает OnCollisionEnter/Exit.
    public float RunAwayDistance;
}
