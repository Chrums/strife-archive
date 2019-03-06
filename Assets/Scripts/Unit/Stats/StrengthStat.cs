using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthStat : UnitStat<StrengthStat>
{
    [SerializeField]
    private float value = 0.0f;

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
}
