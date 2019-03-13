using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiableStat<T, D> : Stat<T> where T : Stat<T> where D : new()
{
    private ModifiableStruct<D> modifiable = new ModifiableStruct<D>();

    public D Value
    {
        get
        {
            return this.modifiable.Value;
        }
    }

    public ModifierStruct<D> Modify(Func<D, D> transform)
    {
        return this.modifiable.Modify(transform);
    }
}
