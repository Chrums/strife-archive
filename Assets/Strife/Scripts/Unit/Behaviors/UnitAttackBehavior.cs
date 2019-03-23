using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(VisionStat))]
    public class UnitAttackBehavior : UnitBehavior
    {
        private VisionStat visionStat = null;

        public override bool Query()
        {
            // TODO: Check if an enemy unit is within vision...
            return true;
        }

        protected override void Awake()
        {
            base.Awake();

            this.visionStat = this.GetComponent<VisionStat>();
        }
    }
}