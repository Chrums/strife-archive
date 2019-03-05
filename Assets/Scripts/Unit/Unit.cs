using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private ActionManager actionManager = new ActionManager();

    public StatManager Stats
    {
        get;
        private set;
    }
    = new StatManager();

    public void On<T>(Action<T> action) where T : class
    {
        this.actionManager.On(action);
    }

    public void Emit<T>(T value) where T : class
    {
        this.actionManager.Emit(value);
    }
}
