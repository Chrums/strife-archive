using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScalableStat<T> : Stat<T> where T : Stat<T>
{
    [SerializeField]
    private float initialBase = 100.0f;

    [SerializeField]
    private float initialMultiplier = 1.0f;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float initialPercentage = 100.0f;

    private float current = default;

    public ModifiableStruct<float> Base
    {
        get;
        private set;
    }
    = null;

    public ModifiableStruct<float> Multiplier
    {
        get;
        private set;
    }
    = null;

    public float Maximum
    {
        get;
        private set;
    }
    = 0.0f;

    public float Current
    {
        get
        {
            return this.current;
        }

        set
        {
            this.current = Mathf.Clamp(value, 0.0f, this.Maximum);
        }
    }

    protected float InitialPercentage
    {
        get
        {
            return this.initialPercentage;
        }

        set
        {
            this.initialPercentage = Mathf.Clamp(value, 0.0f, 100.0f);
        }
    }

    protected override void Awake()
    {
        this.Base = new ModifiableStruct<float>(this.initialBase);
        this.Base.OnChange += this.OnChange;
        this.Multiplier = new ModifiableStruct<float>(this.initialMultiplier);
        this.Multiplier.OnChange += this.OnChange;
        this.Maximum = this.Base.Value * this.Multiplier.Value;
        this.Current = this.Maximum * this.initialPercentage / 100.0f;
    }

    private void OnChange()
    {
        float percent = this.Current / this.Maximum;
        this.Maximum = this.Base * this.Multiplier;
        this.Current = percent * this.Maximum;
    }
}