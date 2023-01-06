using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyHealth : Health
{
    private void OnMouseDown()
    {
        GetDamage(1);
    }
}
