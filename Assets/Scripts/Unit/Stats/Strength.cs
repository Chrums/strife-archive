using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : Stat
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
