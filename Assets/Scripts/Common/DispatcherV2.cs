using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispatcherV2 : MonoBehaviour
{

    private DispatchableV2 m_Active = null;
    private SortedDictionary<float, List<DispatchableV2>> m_Dispatchables = new SortedDictionary<float, List<DispatchableV2>>();
    
    private void Update()
    {

        if (m_Active != null)
            if (!m_Active.Run())
                m_Active = null;

        Dispatch();

    }

    public void Register(float priority, DispatchableV2 dispatchable)
    {
        List<DispatchableV2> dispatchables;
        if (!m_Dispatchables.TryGetValue(priority, out dispatchables))
        {
            dispatchables = new List<DispatchableV2>();
            m_Dispatchables[priority] = dispatchables;
        }
        dispatchables.Add(dispatchable);
    }

    private void Dispatch()
    {
        foreach (KeyValuePair<float, List<DispatchableV2>> priority in m_Dispatchables)
            foreach (DispatchableV2 dispatchable in priority.Value)
                if (dispatchable.Query())
                {
                    if (m_Active == null)
                        m_Active = dispatchable;
                    else if (m_Active.Interrupt(dispatchable))
                        m_Active = dispatchable;
                }
    }

}
