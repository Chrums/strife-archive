using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronousDispatcher : MonoBehaviour
{

    private SynchronousDispatchable m_Active = null;
    private SortedDictionary<float, List<SynchronousDispatchable>> m_Dispatchables = new SortedDictionary<float, List<SynchronousDispatchable>>();
    
    private void Update()
    {

        if (m_Active != null)
            if (m_Active.Run())
                m_Active = null;

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
    }

    private void Dispatch()
    {
        foreach (KeyValuePair<float, List<SynchronousDispatchable>> priority in m_Dispatchables)
            foreach (SynchronousDispatchable dispatchable in priority.Value)
                if (dispatchable.Query())
                {
                    if (m_Active == null)
                        m_Active = dispatchable;
                    else if (m_Active.Interrupt(dispatchable))
                        m_Active = dispatchable;
                }
    }

}
