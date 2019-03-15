using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(Unit))]
    public abstract class UnitBehavior : PriorityBehavior, IUnitBehavior
    {
        public Unit Unit
        {
            get;
            private set;
        }
        = null;

        protected override void Awake()
        {
            base.Awake();
            this.Unit = this.GetComponent<Unit>();
        }
    }
}