using UnityEngine;

namespace Fizz6.Core
{
    [RequireComponent(typeof(StatManager))]
    public abstract class Stat<D> : StatBase where D : Stat<D>
    {
        protected override void Awake()
        {
            base.Awake();
            this.Manager.Add(this as D);
        }
    }
}