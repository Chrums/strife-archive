using System.Linq;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(Unit))]
    [RequireComponent(typeof(PositionStat))]
    [RequireComponent(typeof(RangeStat))]
    public class UnitMovementBehavior : MovementBehavior, IUnitBehavior
    {
        private PositionStat boardPositionStat = null;

        private RangeStat rangeStat = null;

        public Unit Unit
        {
            get;
            protected set;
        }
        = null;

        public override bool Query()
        {
            return base.Query() && !this.Unit.Board.IsEnemyUnitInRange(this.Unit, this.rangeStat.Current);
        }

        public override void Activate()
        {
            base.Activate();
            this.Target = this.CalculateTarget();
            if (!this.Target.HasValue)
            {
                this.Yield();
                return;
            }

            this.boardPositionStat.Cell = new Vector2Int((int)this.Target.Value.x, (int)this.Target.Value.y);
        }

        protected override void Awake()
        {
            base.Awake();
            this.Unit = this.GetComponent<Unit>();
            this.boardPositionStat = this.GetComponent<PositionStat>();
            this.rangeStat = this.GetComponent<RangeStat>();
            this.Unit.transform.position = (Vector2)this.boardPositionStat.Cell;
        }

        protected virtual Vector2Int? CalculateTarget()
        {
            Unit targetUnit = this.Unit.Board.Units
                .Where(unit => unit.Player != this.Unit.Player)
                .Aggregate(null, (Unit target, Unit unit) => target == null ? unit : Vector2.Distance(this.Unit.Position.Cell, unit.Position.Cell) < Vector2.Distance(this.Unit.Position.Cell, target.Position.Cell) ? unit : target);

            if (targetUnit)
            {
                return this.Unit.Board.GetFurthestAvailableCellInRange(this.Unit.transform.position, targetUnit.transform.position, this.rangeStat.Current);
            }
            else
            {
                return null;
            }
        }
    }
}