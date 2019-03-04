using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PriorityBehaviorManager))]
public abstract class PriorityBehavior : MonoBehaviour
{

    [SerializeField]
    private float m_Priority = 0.0f;
    public float priority { get { return m_Priority; } protected set { m_Priority = value; } }

    private PriorityBehaviorManager m_Dispatcher;

    protected virtual void Awake()
    {
        m_Dispatcher = GetComponent<PriorityBehaviorManager>();
        m_Dispatcher.Register(m_Priority, this);
    }

    public virtual bool Query()
    {
        return false;
    }

    public virtual void Activate()
    { }

    public virtual void Deactivate()
    { }

    public virtual bool Interrupt(PriorityBehavior dispatchable)
    {
        return false;
    }

    protected void Yield()
    {
        m_Dispatcher.Yield(this);
    }

}
