using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Stat
{
    [SerializeField]
    private float value = 100.0f;
    
    private float multiplier = 1.0f;

    public float Current
    {
        get;
        private set;
    }
    = 0.0f;

    private void Awake()
    {
        this.Unit.On<UnitReset>(this.Reset);
    }

    private void Reset(UnitReset unitReset)
    {
        this.Current = value * multiplier;
    }
}
