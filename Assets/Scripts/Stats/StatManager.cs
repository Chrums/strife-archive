using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    private Dictionary<Type, IStat> stats = new Dictionary<Type, IStat>();

    public void Add<T>(T value) where T : IStat
    {
        Type key = typeof(T);
        if (!this.stats.ContainsKey(key))
        {
            this.stats.Add(key, value);
        }
    }

    public void Remove<T>(T value) where T : IStat
    {
        Type key = typeof(T);
        if (this.stats.ContainsKey(key))
        {
            this.stats.Remove(key);
        }
    }

    public T Get<T>() where T : IStat
    {
        Type key = typeof(T);
        IStat value;
        this.stats.TryGetValue(key, out value);
        return value as T;
    }
}