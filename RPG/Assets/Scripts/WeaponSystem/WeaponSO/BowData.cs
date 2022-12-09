using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBow", menuName = "Create new bow")]
public class BowData : WeaponData
{
    [SerializeField] public GameObject arrow;
}
