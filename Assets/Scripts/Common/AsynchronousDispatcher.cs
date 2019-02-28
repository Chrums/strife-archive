using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AsynchronousDispatcher : MonoBehaviour
{
    
    private AsynchronousDispatchable m_Active;
    private SortedDictionary<float, List<AsynchronousDispatchable>> m_Dispatchables = new SortedDictionary<float, List<AsynchronousDispatchable>>();

    private void Update()
    {
        Dispatch();
    }

    public void Register(float priority, AsynchronousDispatchable dispatchable)
    {
        List<AsynchronousDispatchable> dispatchables;
        if (!m_Dispatchables.TryGetValue(priority, out dispatchables))
        {
            dispatchables = new List<AsynchronousDispatchable>();
            m_Dispatchables[priority] = dispatchables;
        }
        dispatchables.Add(dispatchable);
    }

    private void Dispatch()
    {
        foreach (KeyValuePair<float, List<AsynchronousDispatchable>> priority in m_Dispatchables)
            foreach (AsynchronousDispatchable dispatchable in priority.Value)
                if (dispatchable.Query())
                    if (Lock(dispatchable))
                        StartCoroutine(Invoke(dispatchable));
                    
    }

    private IEnumerator Invoke(AsynchronousDispatchable dispatchable)
    {
        yield return StartCoroutine(dispatchable.Run());
        Unlock(dispatchable);
    }

    public bool Lock(AsynchronousDispatchable dispatchable)
    {
        if (m_Active == null)
        {
            m_Active = dispatchable;
            return true;
        }
        else
        {
            bool yield = m_Active.Yield(dispatchable);
            if (yield) Yield(dispatchable);
            return yield;
        }
    }

    public void Unlock(AsynchronousDispatchable dispatchable)
    {
        if (m_Active == dispatchable)
        {
            m_Active = null;
        }
    }

    private void Yield(AsynchronousDispatchable dispatchable)
    {
        m_Active = dispatchable;
    }

}