using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyHealth : Health
{
    private void OnMouseDown()
    {
        GetDamage(1);
    }
}
