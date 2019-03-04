using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispatcher
{

    private Dictionary<Type, Action<object>> m_Actions = new Dictionary<Type, Action<object>>();

    public void On<T>(Action<T> action) where T : class
    {
        Type key = typeof(T);
        Action<object> value = Convert(action);
        if (m_Actions.ContainsKey(key))
            m_Actions[key] += value;
        else
            m_Actions[key] = value;
    }

    public void Emit<T>(T item) where T : class
    {
        Type key = typeof(T);
        if (m_Actions.ContainsKey(key))
            m_Actions[key]?.Invoke(item);
    }

    public Action<object> Convert<T>(Action<T> action)
    {
        return new Action<object>((object o) => action((T)o));
    }

}