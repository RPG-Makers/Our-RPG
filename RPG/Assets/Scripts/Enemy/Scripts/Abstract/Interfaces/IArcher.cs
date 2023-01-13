using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArcher
{
    BowData BowData { get; set; }
    void RangeAttack();
}
