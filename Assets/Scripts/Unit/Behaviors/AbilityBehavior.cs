using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBehavior : UnitBehavior
{

    [SerializeField]
    private float cost = 100.0f;

    [SerializeField]
    private float cooldown = 10.0f;

    private float charge = 0.0f;

    private float cooldownCount = 0.0f;

    public override bool Query()
    {
        return charge > cost && cooldownCount > cooldown;
    }

    public override void Activate()
    {
        base.Activate();
        charge -= cost;
        cooldownCount = 0.0f;
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
        //Unit.On<Damage>(this.OnDamage);
    }

    private void Update()
    {
        cooldownCount += Time.deltaTime;
    }

    //protected virtual OnDamage(Damage damage)
    //{
    //    if (damage.by == this.Unit)
    //    {
    //        charge += damage.amount;
    //    }
    //    else if (damage.to == this.Unit)
    //    {
    //        charge += damage.amount * 2.0f;
    //    }
    //}
}
