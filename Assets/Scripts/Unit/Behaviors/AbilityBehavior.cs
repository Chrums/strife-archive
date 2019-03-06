using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehavior : UnitBehavior
{
    [SerializeField]
    private float cooldown = 10.0f;

    [SerializeField]
    private float cost = 100.0f;

    private float charge = 0.0f;

    private float timer = 0.0f;

    public override bool Query()
    {
        return this.charge > this.cost && this.timer < 0.0f;
    }

    public override void Activated()
    {
        base.Activated();
        this.charge -= this.cost;
        this.timer = this.cooldown;
    }

    public override void Deactivated()
    {
        base.Deactivated();
    }

    public override void Pumped()
    {
        base.Pumped();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        this.timer += Time.deltaTime;
    }
}
