using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private Dictionary<Type, Action<object>> actions = new Dictionary<Type, Action<object>>();

    public void On<T>(Action<T> action) where T : class
    {
        Type key = typeof(T);
        Action<object> value = this.Convert(action);
        this.actions[key] += value;
    }

    public void Emit<T>(T value) where T : class
    {
        Type key = typeof(T);
        this.actions[key]?.Invoke(value);
    }

    private Action<object> Convert<T>(Action<T> action)
    {
        return new Action<object>((object o) => action((T)o));
    }
}
