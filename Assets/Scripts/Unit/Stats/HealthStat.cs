using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStat : UnitStat<HealthStat>
{
    [SerializeField]
    private float basic = 100.0f;
    
    private float multiplier = 1.0f;

    public float Current
    {
        get;
        set;
    }
    = 0.0f;

    public float Basic
    {
        get
        {
            return this.basic;
        }

        set
        {
            this.Current = this.Current / this.multiplier / this.basic * value * this.multiplier;
            this.basic = value;
        }
    }

    public float Multiplier
    {
        get
        {
            return this.multiplier;
        }

        set
        {
            this.Current = this.Current / this.multiplier * value;
            this.multiplier = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.Current = this.basic * this.multiplier;
    }
}
