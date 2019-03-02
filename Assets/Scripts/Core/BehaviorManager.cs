using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{

    private Behavior m_Active = null;
    private SortedDictionary<float, List<Behavior>> m_Dispatchables = new SortedDictionary<float, List<Behavior>>();
    
    private void Update()
    {
        Dispatch();
    }

    public void Register(float priority, Behavior dispatchable)
    {
        List<Behavior> dispatchables;
        if (!m_Dispatchables.TryGetValue(priority, out dispatchables))
        {
            dispatchables = new List<Behavior>();
            m_Dispatchables[priority] = dispatchables;
        }
        dispatchables.Add(dispatchable);
        dispatchable.enabled = false;
    }

    private void Dispatch()
    {
        foreach (KeyValuePair<float, List<Behavior>> priority in m_Dispatchables)
            foreach (Behavior dispatchable in priority.Value)
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

    private void Activate(Behavior dispatchable)
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

    public void Yield(Behavior dispatchable)
    {
        if (m_Active == dispatchable)
        {
            Deactivate();
        }
    }

}
