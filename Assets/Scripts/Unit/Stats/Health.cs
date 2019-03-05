using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Stat
{
    [SerializeField]
    private float points = 100.0f;

    [SerializeField]
    private float multiplier = 1.0f;

    public float Points
    {
        get
        {
            return this.points;
        }

        set
        {
            this.Current = ((this.Current / this.multiplier) / this.points) * value * this.multiplier;
            this.points = value;
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
            this.Current = (this.Current / this.multiplier) * value;
            this.multiplier = value;
        }
    }

    public float Current
    {
        get;
        private set;
    }
    = 0.0f;

    private void Awake()
    {
        this.Reset();
    }

    private void Reset()
    {
        this.Current = this.points * this.multiplier;
    }
}
