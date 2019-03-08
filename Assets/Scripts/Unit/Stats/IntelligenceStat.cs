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
            this.value = value;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.manaStat = this.GetComponent<ManaStat>();
        this.manaStat.Base += this.value * this.manaPerIntelligence;
    }
}
