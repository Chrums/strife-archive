using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackAction))]
public class DefaultMovement : MovementAction
{
    
    private AttackAction m_AttackAction;

    protected override void Awake()
    {
        base.Awake();
        m_AttackAction = GetComponent<AttackAction>();
    }

    public override IEnumerator Run()
    {
        yield return new WaitForSeconds(1.0f);
        Unit target = unit.board.GetNearestEnemyUnit(unit);
        if (Vector2.Distance(unit.position, target.position) > m_AttackAction.range)
        {
            int x = unit.position.x < target.position.x
                ? 1
                : unit.position.x > target.position.x
                ? -1
                : 0;
            int y = unit.position.y < target.position.y
                ? 1
                : unit.position.y > target.position.y
                ? -1
                : 0;
            Vector2Int targetPosition = new Vector2Int(unit.position.x + x, unit.position.y + y);
            Debug.Log(string.Format("{0} moving to {1}", unit, targetPosition));
            if (!unit.board.IsPositionOccupied(targetPosition)) unit.position = targetPosition;
        }
    }

}
