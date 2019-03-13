using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TestStat : Stat<TestStat>
{
    [SerializeField]
    private float initialBase = 100.0f;

    [SerializeField]
    private float initialMultiplier = 1.0f;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    private float initialPercentage = 100.0f;

    private float current = default;
    
    public Modifiable<float> Base
    {
        get;
        private set;
    }
    = null;

    public Modifiable<float> Multiplier
    {
        get;
        private set;
    }
    = null;

    public float Maximum
    {
        get;
        private set;
    }
    = 0.0f;

    public float Current
    {
        get
        {
            return this.current;
        }

        set
        {
            this.current = Mathf.Clamp(value, 0.0f, this.Maximum);
        }
    }

    protected override void Awake()
    {
        this.Base = new Modifiable<float>(this.initialBase);
        this.Base.OnChange += this.OnChange;
        this.Multiplier = new Modifiable<float>(this.initialMultiplier);
        this.Multiplier.OnChange += this.OnChange;
        this.Maximum = this.Base.Value * this.Multiplier.Value;
        this.Current = this.Maximum * this.initialPercentage / 100.0f;
    }

    private void OnChange()
    {
        float percent = this.Current / this.Maximum;
        this.Maximum = this.Base * this.Multiplier;
        this.Current = percent * this.Maximum;
    }
}
