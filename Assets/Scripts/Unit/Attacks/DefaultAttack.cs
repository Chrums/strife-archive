using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : AttackAction
{

    public override IEnumerator Run()
    {
        Unit target = unit.board.GetNearestEnemyUnit(unit);
        if (target != null)
        {
            Debug.Log(string.Format("{0} attacking {1}!", unit, target));
            yield return new WaitForSeconds(2.0f);
            unit.onDamageDealt?.Invoke(Random.Range(2, 5));
        }
    }

}
