using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(RangeStat))]
    public class AttackBehavior : UnitBehavior
    {
        private RangeStat rangeStat = null;

        private Unit target = null;

        public AttackBehavior()
        {
            this.Priority = 0.4f;
        }

        public override bool Query()
        {
            this.target = this.Unit.Board.Units
                .Where(unit => unit.Player != this.Unit.Player)
                .OrderBy(unit => Vector2.Distance(this.Unit.Position.Cell, unit.Position.Cell))
                .FirstOrDefault();
            if (this.target == null)
            {
                return false;
            }

            return Vector2.Distance(this.Unit.Position.Cell, this.target.Position.Cell) < this.rangeStat.Current;
        }

        public override void Activate()
        {
            base.Activate();
        }

        protected override void Awake()
        {
            base.Awake();
            this.rangeStat = this.GetComponent<RangeStat>();
        }
    }
}