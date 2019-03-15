using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    [RequireComponent(typeof(PriorityBehaviorManager))]
    public abstract class PriorityBehavior : MonoBehaviour, IPriorityBehavior
    {
        private PriorityBehaviorManager priorityBehaviorManager = null;

        [SerializeField]
        private float priority = 0.0f;

        public float Priority
        {
            get
            {
                return this.priority;
            }

            protected set
            {
                this.priority = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return this.priorityBehaviorManager.Active == this;
            }
        }

        public virtual bool Query()
        {
            return false;
        }

        public virtual void Pump()
        {
        }

        public virtual void Activate()
        {
        }

        public virtual void Deactivate()
        {
        }

        public virtual bool Interrupt(PriorityBehavior priorityBehavior)
        {
            return false;
        }

        protected void Yield()
        {
            this.priorityBehaviorManager.Yield(this);
        }

        protected virtual void Awake()
        {
            this.priorityBehaviorManager = this.GetComponent<PriorityBehaviorManager>();
            this.priorityBehaviorManager.Register(this);
        }
    }
}