using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public class BoardPositionStat : Stat<BoardPositionStat>
    {
        public Board Board
        {
            get;
            private set;
        }
        = null;

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
                if (this.Board.IsCellEmpty(value))
                {
                    this.cell = value;
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            this.Board = this.GetComponentInParent<Board>();
        }
    }
}