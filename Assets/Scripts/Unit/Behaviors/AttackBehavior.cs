using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehavior : UnitBehavior
{
    public AttackBehavior()
    {
        this.Priority = 0.4f;
    }

    public override bool Query()
    {
        return false;
    }
}
