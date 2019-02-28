using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AsynchronousDispatcher))]
public abstract class AsynchronousDispatchable : MonoBehaviour
{

    [SerializeField]
    private float m_Priority = 0.0f;
    public float priority { get { return m_Priority; } protected set { m_Priority = value; } }

    private AsynchronousDispatcher m_Dispatcher;
    
    protected virtual void Awake()
    {
        m_Dispatcher = GetComponent<AsynchronousDispatcher>();
        m_Dispatcher.Register(m_Priority, this);
    }

    public virtual bool Query()
    {
        return false;
    }

    public virtual IEnumerator Run()
    {
        yield return null;
    }

    public virtual bool Yield(AsynchronousDispatchable dispatchable)
    {
        return false;
    }

}