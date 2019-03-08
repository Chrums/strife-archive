using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehavior : UnitBehavior
{
    [SerializeField]
    private float cost = 100.0f;

    private float charge = 0.0f;

    [SerializeField]
    private float cooldown = 10.0f;

    private float cooldownTimer = 0.0f;

    public AbilityBehavior()
    {
        this.Priority = 0.2f;
    }

    public override bool Query()
    {
        return this.charge > this.cost && this.cooldownTimer > this.cooldown;
    }

    public override void Activate()
    {
        base.Activate();
        this.charge -= this.cost;
        this.cooldownTimer = 0.0f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
    }

    public override void Pump()
    {
        base.Pump();
    }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        this.cooldownTimer += Time.deltaTime;
    }
}
