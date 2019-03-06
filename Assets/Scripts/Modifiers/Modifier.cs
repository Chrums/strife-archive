using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModifierManager))]
public class Modifier : MonoBehaviour
{
    protected ModifierManager Manager
    {
        get;
        private set;
    }
    = null;
    
    public virtual void Added()
    {
    }

    public virtual void Removed()
    {
    }

    protected virtual void Awake()
    {
        this.Manager = this.GetComponent<ModifierManager>();
    }

    protected void Destroy()
    {
        this.Manager.Remove(this);
    }
}
