using System.Collections;
using System.Collections.Generic;
using Fizz6.Core;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(UnitAttackBehavior))]
    public class UnitAttackMovementBehavior : UnitMovementBehavior
    {
        public override bool Interrupt(PriorityBehavior priorityBehavior)
        {
            return priorityBehavior.GetType().IsSubclassOf(typeof(UnitAttackBehavior));
        }
    }
}