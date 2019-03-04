using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : AbilityAction
{
    private Unit m_Target = null;
    private float m_StartTime = 0.0f;
    private float m_Duration = 5.0f;

    protected override void Awake()
    {
        base.Awake();
        unit.On<Damage>(OnDamage);
    }

    private void OnDamage(Damage damage)
    {
        charge += damage.amount * 2.0f;
    }

    public override void Activate()
    {
        base.Activate();
        m_Target = unit.board.GetFurthestEnemyUnit(unit);
        if (m_Target == null)
        {
            Yield();
        }
        m_StartTime = Time.time;
        charge -= cost;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        m_Target = null;
    }

    private void Update()
    {
        if (Time.time - m_StartTime >= m_Duration)
            Yield();
    }

}
