using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public abstract class UnitAction : Dispatchable
{

    private Unit m_Unit;
    protected Unit unit { get { return m_Unit; } }

    protected override void Awake()
    {
        base.Awake();
        m_Unit = GetComponent<Unit>();
    }

}
