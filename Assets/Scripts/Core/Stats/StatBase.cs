using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    [RequireComponent(typeof(StatManager))]
    public abstract class StatBase : MonoBehaviour, IStat
    {
        protected StatManager Manager
        {
            get;
            private set;
        }
        = null;

        protected virtual void Awake()
        {
            this.Manager = this.GetComponent<StatManager>();
        }
    }
}