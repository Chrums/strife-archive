using UnityEngine;

namespace Fizz6.Strife
{
    public class PositionStat : UnitStat<PositionStat>
    {
        [SerializeField]
        private Vector2Int cell = new Vector2Int(0, 0);

        public Vector2Int Cell
        {
            get
            {
                return this.cell;
            }

            set
            {
                if (this.Unit.Board.IsCellEmpty(value))
                {
                    this.cell = value;
                }
            }
        }
    }
}