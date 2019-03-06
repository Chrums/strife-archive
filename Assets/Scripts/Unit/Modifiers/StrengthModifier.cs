using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthModifier : UnitModifier
{
    [SerializeField]
    private float healthPerStrength = 10.0f;

    private StrengthStat strengthStat = null;
    private HealthStat healthStat = null;

    public override void Added()
    {
        base.Added();
        this.healthStat.Basic += strengthStat.Value * healthPerStrength;
    }

    public override void Removed()
    {
        base.Removed();
        this.healthStat.Basic -= strengthStat.Value * healthPerStrength;
    }

    protected override void Awake()
    {
        base.Awake();
        this.strengthStat = this.Unit.Stats.Get<StrengthStat>();
        this.healthStat = this.Unit.Stats.Get<HealthStat>();
    }
}
