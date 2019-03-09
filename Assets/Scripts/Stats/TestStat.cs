using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalable
{
    private float value = 100.0f;

    private float multiplier = 1.0f;
    
    private float current = default;

    public Scalable()
    {
        this.Maximum = value * multiplier;
        this.Current = this.Maximum;
    }

    public float Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.Maximum = value * this.multiplier;
            this.Current = this.Current / this.multiplier / this.value * value * this.multiplier;
            this.value = value;
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
            this.Maximum = this.value * value;
            this.Current = this.Current / this.multiplier * value;
            this.multiplier = value;
        }
    }

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
}

public class TestStat : Stat<TestStat>
{
    [SerializeField]
    private float baseValue = 100.0f;

    [SerializeField]
    private float multiplierValue = 1.0f;

    private float current = default;

    public Modifiable<float> Base
    {
        get;
        private set;
    }
    = null;

    public Modifiable<float> Multiplier
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

    protected override void Awake()
    {
        this.Base = new Modifiable<float>(this.baseValue);
        this.Base.OnModify += this.OnBaseModify;
        this.Multiplier = new Modifiable<float>(this.multiplierValue);
        this.Maximum = this.baseValue * this.multiplierValue;
        this.Current = this.Maximum;
    }

    private void OnBaseModify(float value)
    {

    }
}
