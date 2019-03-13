using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierStruct<T> where T : struct
{
    private ModifiableStruct<T> modifiable = null;

    public Func<T, T> transform = null;

    public Func<T, T> Transform
    {
        get
        {
            return this.transform;
        }

        set
        {
            this.Modify(value);
        }
    }

    public ModifierStruct(ModifiableStruct<T> modifiable, Func<T, T> transform)
    {
        this.modifiable = modifiable;
        this.transform = transform;
    }

    public void Modify(Func<T, T> transform)
    {
        this.transform = transform;
        this.modifiable.Calculate();
    }

    public void Destroy()
    {
        this.modifiable.Destroy(this);
    }
}