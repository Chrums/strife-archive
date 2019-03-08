using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackBehavior : UnitBehavior
{
    [SerializeField]
    private float range = 10.0f;

    private Unit target = null;
    
    public AttackBehavior()
    {
        this.Priority = 0.4f;
    }

    public override bool Query()
    {
        this.target = this.Unit.Board.Units
            .Where(unit => unit.Position.Cell != null)
            .Where(unit => unit.Player != this.Unit.Player)
            .OrderBy(unit => Vector2.Distance(this.Unit.Position.Cell, unit.Position.Cell))
            .FirstOrDefault();
        return this.target == null
            ? false
            : Vector2.Distance(this.Unit.Position.Cell, this.target.Position.Cell) < this.range;
    }

    public override void Activate()
    {
        base.Activate();

    }
}
