using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthStat : UnitStat<StrengthStat>
{
    [SerializeField]
    private float value = 0.0f;

    private StrengthModifier strengthModifier = null;

    public float Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.value = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.strengthModifier = this.Unit.Modifiers.Add<StrengthModifier>();
    }
}
