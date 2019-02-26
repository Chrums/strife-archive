using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAbility : AbilityAction
{

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

    public override IEnumerator Run()
    {
        Unit target = unit.board.GetFurthestEnemyUnit(unit);
        if (target != null)
        {
            charge -= cost;
            Debug.Log(string.Format("{0} casting fireball on {1}", unit, target));
            yield return new WaitForSeconds(1.0f);
        }
    }

}
