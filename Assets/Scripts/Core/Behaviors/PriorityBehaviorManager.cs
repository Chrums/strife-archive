using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class PriorityBehaviorManager : MonoBehaviour
    {
        private SortedDictionary<float, PriorityBehavior> priorityBehaviors = new SortedDictionary<float, PriorityBehavior>();

        public PriorityBehavior Active
        {
            get;
            private set;
        }
        = null;

        public void Register(PriorityBehavior priorityBehavior)
        {
            if (this.priorityBehaviors.ContainsKey(priorityBehavior.Priority))
            {
                Debug.LogError(string.Format("Multiple PriorityBehaviors registered with Priority: {0}", priorityBehavior.Priority));
                return;
            }

            this.priorityBehaviors[priorityBehavior.Priority] = priorityBehavior;
        }

        public void Yield(PriorityBehavior priorityBehavior)
        {
            if (this.Active == priorityBehavior)
            {
                this.Deactivate(priorityBehavior);
            }
        }

        private void Update()
        {
            foreach (KeyValuePair<float, PriorityBehavior> priority in this.priorityBehaviors)
            {
                PriorityBehavior priorityBehavior = priority.Value;
                if (priorityBehavior.Query())
                {
                    if (this.Active == null)
                    {
                        this.Activate(priorityBehavior);
                    }
                    else if (this.Active.Interrupt(priorityBehavior))
                    {
                        this.Deactivate(this.Active);
                        this.Activate(priorityBehavior);
                    }
                }
            }

            if (this.Active != null)
            {
                this.Active.Pump();
            }
        }

        private void Activate(PriorityBehavior priorityBehavior)
        {
            if (this.Active == null)
            {
                this.Active = priorityBehavior;
                this.Active.Activate();
            }
        }

        private void Deactivate(PriorityBehavior priorityBehavior)
        {
            if (this.Active == priorityBehavior)
            {
                this.Active.Deactivate();
                this.Active = null;
            }
        }
    }
}