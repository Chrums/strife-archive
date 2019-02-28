using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SynchronousDispatcher))]
public abstract class SynchronousDispatchable : MonoBehaviour
{

    [SerializeField]
    private float m_Priority = 0.0f;
    public float priority { get { return m_Priority; } protected set { m_Priority = value; } }

    private SynchronousDispatcher m_Dispatcher;

    protected virtual void Awake()
    {
        m_Dispatcher = GetComponent<SynchronousDispatcher>();
        m_Dispatcher.Register(m_Priority, this);
    }

    public virtual bool Query()
    {
        return false;
    }

    public virtual bool Run()
    {
        return true;
    }

    public virtual bool Interrupt(SynchronousDispatchable dispatchable)
    {
        return false;
    }

}
