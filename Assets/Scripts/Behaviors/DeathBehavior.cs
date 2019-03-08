using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthStat))]
public class DeathBehavior : PriorityBehavior
{
    private HealthStat healthStat = null;

    public DeathBehavior()
    {
        this.Priority = -1.0f;
    }

    public override bool Query()
    {
        return this.healthStat.Current == 0;
    }

    public override void Activate()
    {
        base.Activate();
    }

    protected override void Awake()
    {
        base.Awake();
        this.healthStat = this.GetComponent<HealthStat>();
    }
}
