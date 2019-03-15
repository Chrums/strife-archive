using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(Unit))]
    public abstract class UnitStat<T> : Stat<T>, IUnitStat where T : Stat<T>
    {
        public Unit Unit
        {
            get;
            private set;
        }

        protected override void Awake()
        {
            base.Awake();
            this.Unit = this.GetComponent<Unit>();
        }
    }
}