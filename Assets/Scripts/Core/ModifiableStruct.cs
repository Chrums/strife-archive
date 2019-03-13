using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModifiableStruct<T> where T : new()
{
    public static implicit operator T(ModifiableStruct<T> modifiable)
    {
        return modifiable.Value;
    }

    private T initial = default;
    private List<ModifierStruct<T>> modifiers = new List<ModifierStruct<T>>();

    public delegate void OnChangeDelegate();
    public OnChangeDelegate OnChange = default;

    public T Value
    {
        get;
        private set;
    }
    = default;

    public ModifiableStruct(T initial = default)
    {
        this.initial = initial;
        this.Value = initial;
    }

    public ModifierStruct<T> Modify(Func<T, T> transform)
    {
        ModifierStruct<T> modifier = new ModifierStruct<T>(this, transform);
        this.modifiers.Add(modifier);
        this.Calculate();
        return modifier;
    }

    public void Destroy(ModifierStruct<T> wrapper)
    {
        this.modifiers.Remove(wrapper);
        this.Calculate();
    }

    public void Calculate()
    {
        this.Value = this.modifiers.Aggregate(initial, this.Aggregator);
        this.OnChange?.Invoke();
    }

    private T Aggregator(T value, ModifierStruct<T> modifier)
    {
        value = modifier.Transform(value);
        return value;
    }
}
