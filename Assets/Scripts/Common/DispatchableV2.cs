using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DispatchableV2 : MonoBehaviour
{

    [SerializeField]
    private float m_Priority = 0.0f;
    public float priority { get { return m_Priority; } protected set { m_Priority = value; } }

    private DispatcherV2 m_Dispatcher;

    void Start()
    {
        m_Dispatcher = GetComponent<DispatcherV2>();
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

    public virtual bool Interrupt(DispatchableV2 dispatchable)
    {
        return false;
    }

}
