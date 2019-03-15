using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;

namespace Fizz6.Strife
{
    public class DamageEvent : Event
    {
        public DamageEvent(Unit source, Unit target, float amount)
        {
            this.Source = source;
            this.Target = target;
            this.Amount = amount;
        }

        public Unit Source
        {
            get;
            private set;
        }
        = null;

        public Unit Target
        {
            get;
            private set;
        }
        = null;

        public float Amount
        {
            get;
            set;
        }
        = 0.0f;
    }
}