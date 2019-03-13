using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ManaStat))]
public class IntelligenceStat : Stat<IntelligenceStat>
{
    [SerializeField]
    private float value = 0.0f;

    [SerializeField]
    private float manaPerIntelligence = 10.0f;

    private ModifierStruct<float> manaBaseModifier = null;

    public float Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.manaBaseModifier.Modify(manaBase => manaBase + value * this.manaPerIntelligence);
            this.value = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        ManaStat manaStat = this.GetComponent<ManaStat>();
        this.manaBaseModifier = manaStat.Base.Modify(manaBase => manaBase + this.value * this.manaPerIntelligence);
    }
}
