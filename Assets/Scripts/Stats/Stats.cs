using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{

    private Dictionary<Type, Stat> m_Stats = new Dictionary<Type, Stat>();

    public void Add<T>(T stat) where T : Stat
    {
        m_Stats.Add(typeof(T), stat);
    }

    public T Get<T>() where T : Stat
    {
        return m_Stats[typeof(T)] as T;
    }

}