using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatManager))]
public abstract class IStat : MonoBehaviour
{
    protected StatManager Manager
    {
        get;
        private set;
    }
    = null;

    protected virtual void Awake()
    {
        this.Manager = this.GetComponent<StatManager>();
    }
}
