using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier<T> where T : struct
{
    private Modifiable<T> modifiable = null;

    public Func<T, T> Transform
    {
        get;
        private set;
    }
    = null;

    public Modifier(Modifiable<T> modifiable, Func<T, T> transform)
    {
        this.modifiable = modifiable;
        this.Transform = transform;
    }

    public void Destroy()
    {
        this.modifiable.Destroy(this);
    }
}