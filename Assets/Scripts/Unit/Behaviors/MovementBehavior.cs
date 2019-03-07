using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementBehavior : UnitBehavior
{
    public MovementBehavior()
    {
        this.Priority = 0.6f;
    }

    public override bool Query()
    {
        return true;
    }

    private List<Unit> GetEnemyUnitsByDistance()
    {
        return this.Unit.Board.Units
            .Where(unit => this.Unit.Owner != unit.Owner)
            .OrderBy(unit => Vector2.Distance(this.Unit.Position.Cell, unit.Position.Cell))
            .ToList();
    }
}
