using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityBehaviorManager : MonoBehaviour
{

    private PriorityBehavior m_Active = null;
    private SortedDictionary<float, List<PriorityBehavior>> m_Dispatchables = new SortedDictionary<float, List<PriorityBehavior>>();
    
    private void Update()
    {
        Dispatch();
    }

    public void Register(float priority, PriorityBehavior dispatchable)
    {
        List<PriorityBehavior> dispatchables;
        if (!m_Dispatchables.TryGetValue(priority, out dispatchables))
        {
            dispatchables = new List<PriorityBehavior>();
            m_Dispatchables[priority] = dispatchables;
        }
        dispatchables.Add(dispatchable);
        dispatchable.enabled = false;
    }

    private void Dispatch()
    {
        foreach (KeyValuePair<float, List<PriorityBehavior>> priority in m_Dispatchables)
            foreach (PriorityBehavior dispatchable in priority.Value)
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

    private void Activate(PriorityBehavior dispatchable)
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

    public void Yield(PriorityBehavior dispatchable)
    {
        if (m_Active == dispatchable)
        {
            Deactivate();
        }
    }

}
