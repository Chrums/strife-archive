using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementBehavior : UnitBehavior
{
    private float travelTimer = 0.0f;

    private Vector2Int sourceCell = Vector2Int.zero;

    private Vector2Int targetCell = Vector2Int.zero;
    
    public MovementBehavior()
    {
        this.Priority = 0.6f;
    }

    public override bool Query()
    {
        return true;
    }

    public override void Activated()
    {
        base.Activated();
        this.travelTimer = 0.0f;
        this.sourceCell = this.Unit.Position.Cell;
        this.targetCell = new Vector2Int(Random.Range(0, 9), Random.Range(0, 9));
    }

    public override void Pumped()
    {
        base.Pumped();
        this.travelTimer += Time.deltaTime;
        float t = this.travelTimer / 1.0f;
        this.transform.position = Vector2.Lerp(this.sourceCell, this.targetCell, t);
        if (t >= 1.0f)
        {
            this.Unit.Position.Cell = (Vector2Int)this.targetCell;
            Yield();
        }
    }

    private List<Unit> GetFriendlyUnitsByDistance()
    {
        return this.Unit.Board.Units
            .Where(unit => this.Unit.Owner == unit.Owner)
            .OrderBy(unit => Vector2.Distance(this.Unit.Position.Cell, unit.Position.Cell))
            .ToList();
    }

    private List<Unit> GetEnemyUnitsByDistance()
    {
        return this.Unit.Board.Units
            .Where(unit => this.Unit.Owner != unit.Owner)
            .OrderBy(unit => Vector2.Distance(this.Unit.Position.Cell, unit.Position.Cell))
            .ToList();
    }
}
