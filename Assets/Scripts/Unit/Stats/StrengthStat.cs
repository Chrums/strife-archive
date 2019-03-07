using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthStat))]
public class StrengthStat : UnitStat<StrengthStat>
{
    [SerializeField]
    private float value = 0.0f;

    [SerializeField]
    private float healthPerStrength = 10.0f;

    [SerializeField]
    private float healthRegenerationPerStrength = 1.0f;

    private HealthStat healthStat = null;

    public float Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.healthStat.Base += (this.value * this.healthPerStrength * -1.0f) + (value * this.healthPerStrength);
            this.healthStat.Regeneration += (this.value * this.healthRegenerationPerStrength * -1.0f) + (value * this.healthRegenerationPerStrength);
            this.value = value;
        }
    }

    protected void Start()
    {
        this.healthStat = this.Unit.Stats.Get<HealthStat>();
        this.healthStat.Base += this.value * this.healthPerStrength;
        this.healthStat.Regeneration += this.value * this.healthRegenerationPerStrength;
    }
}
