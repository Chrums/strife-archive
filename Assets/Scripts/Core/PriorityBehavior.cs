using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PriorityBehaviorManager))]
public abstract class PriorityBehavior : MonoBehaviour
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

    public virtual bool Query()
    {
        return false;
    }

    public virtual void Pumped()
    {
    }

    public virtual void Activated()
    {
    }

    public virtual void Deactivated()
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

    private void Awake()
    {
        this.priorityBehaviorManager = this.GetComponent<PriorityBehaviorManager>();
        this.priorityBehaviorManager.Register(this);
    }
}
