using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class VisionStat : ScalableStat<VisionStat>
    {
        public VisionStat()
        {
            this.initialBase = 20.0f;
        }

        public bool HasLineOfSight(Vector3 position)
        {
            return !Physics.Raycast(this.transform.position, position - this.transform.position, this.initialBase);
        }
    }
}