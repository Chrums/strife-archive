﻿using System.Collections;
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
    private float regenerationValue = 0.0f;

    [SerializeField]
    private float regenerationCooldown = 1.0f;

    private float regenerationCooldownTimer = 0.0f;

    public float Base
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

    public float Multiplier
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
            return this.regenerationValue;
        }

        set
        {
            this.regenerationValue = value;
        }
    }

    public float RegenerationCooldown
    {
        get
        {
            return this.regenerationCooldown;
        }

        set
        {
            this.regenerationCooldown = value;
        }
    }

    public float RegenerationPerSecond
    {
        get
        {
            return this.regenerationValue / this.regenerationCooldown;
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
        this.regenerationCooldownTimer += Time.deltaTime;
        if (this.regenerationCooldownTimer > this.regenerationCooldown)
        {
            this.Current += this.Regeneration;
            this.regenerationCooldownTimer -= this.regenerationCooldown;
        }
    }
}