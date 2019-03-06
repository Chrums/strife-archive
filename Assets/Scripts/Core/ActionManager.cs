using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    private Dictionary<Type, Action<object>> actions = new Dictionary<Type, Action<object>>();
    private Hashtable mapping = new Hashtable();

    public void On<T>(Action<T> action) where T : class
    {
        Type key = typeof(T);
        Action<object> value = this.Convert(action);
        if (!this.actions.ContainsKey(key))
        {
            this.actions[key] = value;
        }
        else
        {
            this.actions[key] += value;
        }

        this.mapping.Add(action, value);
    }

    public void Off<T>(Action<T> action) where T : class
    {
        Action<object> value = this.mapping[action] as Action<object>;
        this.actions[typeof(T)] -= value;
        this.mapping.Remove(action);
    }

    public void Emit<T>(T value) where T : class
    {
        Type key = typeof(T);
        if (this.actions.ContainsKey(key))
        {
            this.actions[key]?.Invoke(value);
        }
    }

    private Action<object> Convert<T>(Action<T> action)
    {
        return new Action<object>((object o) => action((T)o));
    }
}
