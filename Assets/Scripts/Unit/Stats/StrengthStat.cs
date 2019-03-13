using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthStat))]
public class StrengthStat : Stat<StrengthStat>
{
    [SerializeField]
    private float value = 0.0f;

    [SerializeField]
    private float healthPerStrength = 10.0f;

    private Modifier<float> healthBaseModifier = null;

    public float Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.healthBaseModifier.Modify((ref float healthBase) => healthBase += value * this.healthPerStrength);
            this.value = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        HealthStat healthStat = this.GetComponent<HealthStat>();
        this.healthBaseModifier = healthStat.Base.Modify((ref float healthBase) => healthBase += this.value * this.healthPerStrength);
    }
}