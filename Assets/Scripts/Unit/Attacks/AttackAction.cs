using UnityEngine;
using System.Collections;
using System.Linq;

public abstract class AttackAction : UnitAction
{

    [SerializeField]
    private int m_Range;
    public int range { get { return m_Range; } protected set { m_Range = value; } }

    public AttackAction() : base()
    {
        priority = 0.5f;
    }

    public override bool Query()
    {
        Unit nearestEnemy = unit.board.GetNearestEnemyUnit(unit);
        if (nearestEnemy != null)
        {
            float distance = Vector2.Distance(unit.position, nearestEnemy.position);
            return distance <= range;
        }
        else
            return false;
    }

}
