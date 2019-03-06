using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{
    public Damage(Unit source, Unit target, float amount)
    {
        this.Source = source;
        this.Target = target;
        this.Amount = amount;
    }

    public Unit Source
    {
        get;
        private set;
    }
    = null;

    public Unit Target
    {
        get;
        private set;
    }
    = null;

    public float Amount
    {
        get;
        set;
    }
    = 0.0f;
}
