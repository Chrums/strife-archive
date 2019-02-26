using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Dispatcher))]
public abstract class Dispatchable : MonoBehaviour
{

    [SerializeField]
    private float m_Priority = 0.0f;
    public float priority { get { return m_Priority; } protected set { m_Priority = value; } }

    private Dispatcher m_Dispatcher;
    
    protected virtual void Awake()
    {
        m_Dispatcher = GetComponent<Dispatcher>();
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

    public virtual bool Yield(Dispatchable dispatchable)
    {
        return false;
    }

}