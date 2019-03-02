using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispatcher
{

    private Dictionary<Type, Action<object>> m_Actions = new Dictionary<Type, Action<object>>();

    public void On<T>(Action<T> action)
    {

        if (m_Actions.ContainsKey(typeof(T)))
        {
            m_Actions[typeof(T)] += action as Action<object>;
            Debug.Log(m_Actions[typeof(T)].GetInvocationList().Length);
        }
        else
        {
            m_Actions.Add(typeof(T), action as Action<object>);
            Debug.Log(m_Actions[typeof(T)].GetInvocationList().Length);
        }
    }

    public void Emit<T>(T item)
    {
        if (m_Actions.ContainsKey(typeof(T)))
        {
            m_Actions[typeof(T)]?.Invoke(item);
            Debug.Log(m_Actions[typeof(T)].GetInvocationList().Length);
        }
    }

}