using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public abstract class Stat : MonoBehaviour
{

    protected Unit unit { get; private set; }

    protected virtual void Awake()
    {
        unit = GetComponent<Unit>();
        unit.stats.Add(this);
    }

    public virtual void Reset()
    { }

}
