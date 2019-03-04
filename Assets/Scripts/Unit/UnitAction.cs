using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public abstract class UnitAction : PriorityBehavior
{

    private Unit m_Unit;
    protected Unit unit { get { return m_Unit; } }

    protected override void Awake()
    {
        base.Awake();
        m_Unit = GetComponent<Unit>();
    }

    //public override bool Interrupt(PriorityBehavior dispatchable)
    //{
    //    if (dispatchable.GetType() == typeof(DeathBehavior))
    //    {
    //        return true;
    //    }
    //    return false;
    //}

    //private void Update()
    //{
    //    Stun stun = m_Unit.Stats.Get<Stun>();
    //    if (!stun.IsStunned)
    //    {
    //        Run();
    //    }
    //}

    //protected virtual void Run()
    //{ }

}
