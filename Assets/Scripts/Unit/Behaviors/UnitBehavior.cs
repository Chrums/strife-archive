using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class UnitBehavior : PriorityBehavior
{
    public Unit Unit
    {
        get;
        private set;
    }

    protected virtual void Awake()
    {
        this.Unit = this.GetComponent<Unit>();
    }
}
