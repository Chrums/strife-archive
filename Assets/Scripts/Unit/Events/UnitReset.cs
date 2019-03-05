using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitReset
{
    public UnitReset(Unit unit)
    {
        this.Unit = unit;
    }

    public Unit Unit
    {
        get;
        private set;
    }
}
