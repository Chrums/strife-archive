using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncapacitatedBehavior : UnitBehavior
{
    private HealthStat healthStat = null;

    public IncapacitatedBehavior()
    {
        this.Priority = 0.0f;
    }

    public override bool Query()
    {
        return this.healthStat.Current == 0;
    }

    public override void Activated()
    {
        base.Activated();
        this.gameObject.SetActive(false);
    }

    protected void Start()
    {
        this.healthStat = this.Unit.Stats.Get<HealthStat>();
    }
}
