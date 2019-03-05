using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityBehaviorManager : MonoBehaviour
{
    private PriorityBehavior activePriorityBehavior = null;
    private SortedDictionary<float, List<PriorityBehavior>> priorityBehaviors = new SortedDictionary<float, List<PriorityBehavior>>();

    public void Register(PriorityBehavior priorityBehavior)
    {
        if (!this.priorityBehaviors.ContainsKey(priorityBehavior.Priority))
        {
            this.priorityBehaviors.Add(priorityBehavior.Priority, new List<PriorityBehavior>());
        }

        this.priorityBehaviors[priorityBehavior.Priority].Add(priorityBehavior);
    }

    public void Yield(PriorityBehavior priorityBehavior)
    {
        if (this.activePriorityBehavior == priorityBehavior)
        {
            this.Deactivate(priorityBehavior);
        }
    }

    private void Update()
    {
        foreach (KeyValuePair<float, List<PriorityBehavior>> priority in this.priorityBehaviors)
        {
            foreach (PriorityBehavior priorityBehavior in priority.Value)
            {
                if (priorityBehavior.Query())
                {
                    if (this.activePriorityBehavior == null)
                    {
                        this.Activate(priorityBehavior);
                    }
                    else if (this.activePriorityBehavior.Interrupt(priorityBehavior))
                    {
                        this.Deactivate(this.activePriorityBehavior);
                        this.Activate(priorityBehavior);
                    }
                }
            }
        }
        
        if (this.activePriorityBehavior != null)
        {
            this.activePriorityBehavior.Pump();
        }
    }

    private void Activate(PriorityBehavior priorityBehavior)
    {
        if (this.activePriorityBehavior == null)
        {
            this.activePriorityBehavior = priorityBehavior;
            this.activePriorityBehavior.Activate();
        }
    }

    private void Deactivate(PriorityBehavior priorityBehavior)
    {
        if (this.activePriorityBehavior == priorityBehavior)
        {
            this.activePriorityBehavior.Deactivate();
            this.activePriorityBehavior = null;
        }
    }
}
