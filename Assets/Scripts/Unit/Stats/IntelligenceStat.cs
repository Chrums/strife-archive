using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ManaStat))]
public class IntelligenceStat : UnitStat<IntelligenceStat>
{
    [SerializeField]
    private float value = 0.0f;

    [SerializeField]
    private float manaPerIntelligence = 10.0f;

    [SerializeField]
    private float manaRegenerationPerIntelligence = 1.0f;

    private ManaStat manaStat = null;

    public float Value
    {
        get
        {
            return this.value;
        }

        set
        {
            this.manaStat.Base += (this.value * this.manaPerIntelligence * -1.0f) + (value * this.manaPerIntelligence);
            this.manaStat.Regeneration += (this.value * this.manaRegenerationPerIntelligence * -1.0f) + (value * this.manaRegenerationPerIntelligence);
            this.value = value;
        }
    }

    protected void Start()
    {
        this.manaStat = this.Unit.Stats.Get<ManaStat>();
        this.manaStat.Base += this.value * this.manaPerIntelligence;
        this.manaStat.Regeneration += this.value * this.manaRegenerationPerIntelligence;
    }
}
