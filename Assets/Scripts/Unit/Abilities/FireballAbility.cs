using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : AbilityAction
{
    private float m_StartTime = 0.0f;
    private float m_Duration = 5.0f;
    private Unit m_Target = null;

    protected override void Awake()
    {
        base.Awake();
        unit.On<DamageDealt>(OnDamageDealt);
        unit.On<DamageTaken>(OnDamageTaken);
    }

    private void OnDamageDealt(DamageDealt data)
    {
        Debug.Log(data);
        charge += data.amount * 2;
    }

    private void OnDamageTaken(DamageTaken data)
    {
        charge += data.amount;
    }

    public override void Activate()
    {
        m_Target = unit.board.GetFurthestEnemyUnit(unit);
        if (m_Target == null)
            Yield();
        m_StartTime = Time.time;
        charge -= cost;
    }

    private void Update()
    {
        if (Time.time - m_StartTime >= m_Duration)
            Yield();
    }

}
