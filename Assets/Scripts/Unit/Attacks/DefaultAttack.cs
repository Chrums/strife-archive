using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultAttack : AttackAction
{

    private void Update()
    {
        Unit target = unit.board.GetNearestEnemyUnit(unit);
        if (target != null)
        {
            Debug.Log(string.Format("{0} attacking {1}", unit, target));
            unit.onDamageDealt?.Invoke(Random.Range(2, 5));
        }
        Yield();
    }

}
