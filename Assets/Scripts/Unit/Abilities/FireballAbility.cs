using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : AbilityAction
{

    private enum State
    {
        Inactive,
        Active,
        Complete
    }

    private State m_State = State.Inactive;

    private void Start()
    {
        unit.onDamageDealt += OnDamageDealt;
        unit.onDamageTaken += OnDamageTaken;
    }

    private void OnDamageDealt(int amount)
    {
        charge += amount * 2;
    }

    private void OnDamageTaken(int amount)
    {
        charge += amount;
    }

    public override bool Run()
    {

        if (m_State == State.Inactive)
        {
            Unit target = unit.board.GetFurthestEnemyUnit(unit);
            if (target != null)
            {
                m_State = State.Active;
                StartCoroutine(Cast(target));
            }
        }

        return m_State == State.Complete;

    }

    public IEnumerator Cast(Unit target)
    {
        charge -= cost;
        Debug.Log(string.Format("{0} casting fireball on {1}", unit, target));
        yield return new WaitForSeconds(1.0f);
        m_State = State.Complete;
    }

}
