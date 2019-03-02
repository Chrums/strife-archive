using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : AttackAction
{

    private float m_StartTime = 0.0f;
    private float m_Duration = 5.0f;

    public override void Activate()
    {

        m_StartTime = Time.time;
        Unit target = unit.board.GetNearestEnemyUnit(unit);

        if (target == null)
            Yield();

        if (target != null)
        {
            Debug.Log(string.Format("{0} attacking {1}", unit, target));
            int amount = Random.Range(2, 5);
            unit.Emit(new DamageDealt(amount));
            target.Emit(new DamageTaken(amount));
        }

    }

    private void Update()
    {
        if (Time.time - m_StartTime >= m_Duration)
            Yield();
    }

}
