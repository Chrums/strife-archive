using System.Collections;
using System.Collections.Generic;
using Fizz6.Core;
using UnityEngine;
using UnityEngine.AI;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class UnitMovementBehavior : UnitBehavior
    {
        [SerializeField]
        private float offset = 0.0f;

        private NavMeshAgent navMeshAgent = null;

        private Vector3? target = null;

        public Vector3? Target
        {
            get
            {
                return this.target;
            }

            set
            {
                this.target = value;
                if (this.target.HasValue)
                {
                    this.navMeshAgent.SetDestination(this.target.Value);
                }
                else
                {
                    this.navMeshAgent.ResetPath();
                }
            }
        }

        protected bool HasArrivedAtTarget
        {
            get
            {
                return Target.HasValue
                    ? Vector3.Distance(this.transform.position, this.Target.Value) <= this.offset
                    : true;
            }
        }

        public override bool Query()
        {
            return this.Target.HasValue;
        }

        public override void Activate()
        {
            base.Activate();

            if (!this.Target.HasValue)
            {
                this.Yield();
                return;
            }

            this.navMeshAgent.isStopped = false;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            this.navMeshAgent.isStopped = true;
        }

        public override void Pump()
        {
            base.Pump();

            if (this.HasArrivedAtTarget)
            {
                this.Target = null;
                this.Yield();
                return;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            this.navMeshAgent = this.GetComponent<NavMeshAgent>();
        }
    }
}
