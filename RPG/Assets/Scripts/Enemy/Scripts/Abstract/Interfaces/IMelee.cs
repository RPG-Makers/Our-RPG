using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMelee
{
    SwordData SwordData { get; set; }
    void MeleeAttack();
}
