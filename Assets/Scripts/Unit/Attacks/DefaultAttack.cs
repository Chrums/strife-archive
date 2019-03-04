using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : AttackAction
{

    private Unit m_Target = null;
    private float m_StartTime = 0.0f;
    private float m_Duration = 5.0f;

    public override void Activate()
    {
        base.Activate();

        m_Target = unit.board.GetFurthestEnemyUnit(unit);
        if (m_Target == null)
        {
            Yield();
        }

        m_StartTime = Time.time;

        Debug.Log(string.Format("{0} attacking {1}", unit, m_Target));
        int amount = Random.Range(10, 20);
        Damage damage = new Damage(unit, m_Target, amount);
        unit.Emit(damage);
        m_Target.Emit(damage);

    }

    private void Update()
    {
        if (Time.time - m_StartTime >= m_Duration)
        {
            Yield();
        }
    }

}
