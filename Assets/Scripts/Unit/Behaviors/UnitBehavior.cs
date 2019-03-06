﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public abstract class UnitBehavior : PriorityBehavior
{
    public Unit Unit
    {
        get;
        private set;
    }
    = null;

    protected virtual void Awake()
    {
        this.Unit = this.GetComponent<Unit>();
    }
}
