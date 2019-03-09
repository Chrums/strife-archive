using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Modifiable<T> where T : struct
{
    private T initial = default;
    private List<Modifier<T>> modifiers = new List<Modifier<T>>();

    public delegate void OnModifyDelegate(T value);
    public OnModifyDelegate OnModify = default;

    public T Value
    {
        get;
        private set;
    }
    = default;

    public Modifiable(T initial = default)
    {
        this.initial = initial;
    }

    public Modifier<T> Modify(Func<T, T> transform)
    {
        Modifier<T> modifier = new Modifier<T>(this, transform);
        this.modifiers.Add(modifier);
        this.Calculate();
        return modifier;
    }

    public void Destroy(Modifier<T> wrapper)
    {
        this.modifiers.Remove(wrapper);
        this.Calculate();
    }

    private void Calculate()
    {
        this.Value = this.modifiers.Aggregate(initial, this.Aggregator);
    }

    private T Aggregator(T value, Modifier<T> modifier)
    {
        value = modifier.Transform(value);
        return value;
    }
}
