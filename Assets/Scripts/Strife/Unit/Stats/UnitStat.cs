using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class UnitStat<T> : Stat<UnitStat<T>>, IUnitStat
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