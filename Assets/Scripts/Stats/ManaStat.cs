using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaStat : ScalableStat<ManaStat>
{
    public ManaStat()
    {
        this.InitialPercentage = 0.0f;
        this.Regeneration = 5.0f;
    }
}