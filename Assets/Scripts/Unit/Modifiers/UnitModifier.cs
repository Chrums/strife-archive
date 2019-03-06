using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public abstract class UnitModifier : Modifier
{
    public Unit Unit
    {
        get;
        private set;
    }
    = null;

    protected override void Awake()
    {
        base.Awake();
        this.Unit = this.GetComponent<Unit>();
    }
}
