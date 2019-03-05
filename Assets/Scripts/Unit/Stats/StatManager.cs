using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager
{
    private Dictionary<Type, Stat> stats = new Dictionary<Type, Stat>();

    public void Add<T>(T value) where T : Stat
    {
        Type key = typeof(T);
        this.stats.Add(key, value);
    }

    public void Remove<T>(T value) where T : Stat
    {
        Type key = typeof(T);
        this.stats.Remove(key);
    }

    public T Get<T>() where T : Stat
    {
        Type key = typeof(T);
        Stat value;
        this.stats.TryGetValue(key, out value);
        return value as T;
    }
}