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
            this.value = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.healthStat = this.GetComponent<HealthStat>();
        this.healthStat.Base += this.value * this.healthPerStrength;
    }
}
