﻿using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(HealthStat))]
    public class HealthRegenerationStat : RegenerationStat<HealthRegenerationStat, HealthStat>
    {
    }
}