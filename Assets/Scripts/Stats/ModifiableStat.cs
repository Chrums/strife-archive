using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiableStat<T, D> : Stat<T> where T : Stat<T> where D : struct
{
    private Modifiable<D> modifiable = new Modifiable<D>();

    public D Value
    {
        get
        {
            return this.modifiable.Value;
        }
    }

    public Modifier<D> Modify(Func<D, D> transform)
    {
        return this.modifiable.Modify(transform);
    }
}
