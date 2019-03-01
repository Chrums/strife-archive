using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronousDispatcher : MonoBehaviour
{

    private SynchronousDispatchable m_Active = null;
    private SortedDictionary<float, List<SynchronousDispatchable>> m_Dispatchables = new SortedDictionary<float, List<SynchronousDispatchable>>();
    
    private void Update()
    {
        Dispatch();
    }

    public void Register(float priority, SynchronousDispatchable dispatchable)
    {
        List<SynchronousDispatchable> dispatchables;
        if (!m_Dispatchables.TryGetValue(priority, out dispatchables))
        {
            dispatchables = new List<SynchronousDispatchable>();
            m_Dispatchables[priority] = dispatchables;
        }
        dispatchables.Add(dispatchable);
        dispatchable.enabled = false;
    }

    private void Dispatch()
    {
        foreach (KeyValuePair<float, List<SynchronousDispatchable>> priority in m_Dispatchables)
            foreach (SynchronousDispatchable dispatchable in priority.Value)
                if (dispatchable.Query())
                {
                    if (m_Active == null)
                        Activate(dispatchable);
                    else if (m_Active.Interrupt(dispatchable))
                    {
                        Deactivate();
                        Activate(dispatchable);
                    }
                }
    }

    private void Activate(SynchronousDispatchable dispatchable)
    {
        if (m_Active == null)
        {
            m_Active = dispatchable;
            m_Active.Activate();
            m_Active.enabled = true;
        }
    }

    private void Deactivate()
    {
        m_Active.enabled = false;
        m_Active.Deactivate();
        m_Active = null;
    }

    public void Yield(SynchronousDispatchable dispatchable)
    {
        if (m_Active == dispatchable)
        {
            Deactivate();
        }
    }

}
