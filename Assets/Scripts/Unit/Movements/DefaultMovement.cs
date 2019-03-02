using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackAction))]
public class DefaultMovement : MovementAction
{

    private float m_StartTime = 0.0f;
    private float m_Duration = 2.0f;

    private AttackAction m_AttackAction;

    protected override void Awake()
    {
        base.Awake();
        m_AttackAction = GetComponent<AttackAction>();
    }

    public override void Activate()
    {

        m_StartTime = Time.time;
        Unit target = unit.board.GetNearestEnemyUnit(unit);

        if (target == null)
            Yield();

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

            if (!unit.board.IsPositionOccupied(targetPosition))
                unit.position = targetPosition;

        }

    }

    private void Update()
    {
        if (Time.time - m_StartTime >= m_Duration)
            Yield();
    }

}
