using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatManager))]
public abstract class Stat<T> : IStat where T : Stat<T>
{
    protected override void Awake()
    {
        base.Awake();
        this.Manager.Add(this as T);
    }
}
