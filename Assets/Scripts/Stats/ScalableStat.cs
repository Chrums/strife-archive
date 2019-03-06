using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScalableStat<T> : Stat<T> where T : Stat<T>
{
    [SerializeField]
    private float baseValue = 100.0f;

    private float baseMultiplier = 1.0f;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float initialPercentage = 100.0f;

    [SerializeField]
    private float current = 0.0f;

    [SerializeField]
    private float regeneration = 0.0f;

    [SerializeField]
    private float regenerationTime = 1.0f;

    private float regenerationTimer = 0.0f;

    public float BaseValue
    {
        get
        {
            return this.baseValue;
        }

        set
        {
            this.Maximum = value * this.baseMultiplier;
            this.Current = this.Current / this.baseMultiplier / this.baseValue * value * this.baseMultiplier;
            this.baseValue = value;
        }
    }

    public float BaseMultiplier
    {
        get
        {
            return this.baseMultiplier;
        }

        set
        {
            this.Maximum = this.baseValue * value;
            this.Current = this.Current / this.baseMultiplier * value;
            this.baseMultiplier = value;
        }
    }

    public float Regeneration
    {
        get
        {
            return this.regeneration;
        }

        set
        {
            this.regeneration = value;
        }
    }

    public float RegenerationTime
    {
        get
        {
            return this.regenerationTime;
        }

        set
        {
            this.regenerationTime = value;
        }
    }

    public float RegenerationPerSecond
    {
        get
        {
            return this.regeneration / this.regenerationTime;
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
        base.Awake();
        this.Maximum = this.baseValue * this.baseMultiplier;
        this.Current = this.Maximum * this.initialPercentage / 100.0f;
    }

    protected void Update()
    {
        this.regenerationTimer += Time.deltaTime;
        if (this.regenerationTimer > this.regenerationTime)
        {
            this.Current += this.Regeneration;
            this.regenerationTimer -= this.regenerationTime;
        }
    }
}