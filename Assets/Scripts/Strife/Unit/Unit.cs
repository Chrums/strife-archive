using Fizz6.Core;
using System;
using UnityEngine;

using Event = Fizz6.Core.Event;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(StatManager))]
    [RequireComponent(typeof(PositionStat))]
    [RequireComponent(typeof(PriorityBehaviorManager))]
    public class Unit : MonoBehaviour
    {
        [SerializeField]
        private Player player = null;

        [SerializeField]
        private Board board = null;

        private EventManager eventManager = new EventManager();

        public Player Player
        {
            get
            {
                return this.player;
            }

            private set
            {
                this.player = value;
            }
        }

        public Board Board
        {
            get
            {
                return this.board;
            }

            private set
            {
                this.board = value;
            }
        }

        public PositionStat Position
        {
            get;
            private set;
        }
        = null;

        public StatManager Stats
        {
            get;
            private set;
        }
        = null;

        public PriorityBehaviorManager Behaviors
        {
            get;
            private set;
        }
        = null;

        public void On<T>(Action<T> action) where T : Event
        {
            this.eventManager.On(action);
        }

        public void Emit<T>(T value) where T : Event
        {
            this.eventManager.Emit(value);
        }

        public void Initialize(Player player, Board board)
        {
            this.player = player;
            this.board = board;
        }

        private void Awake()
        {
            this.Stats = this.GetComponent<StatManager>();
            this.Behaviors = this.GetComponent<PriorityBehaviorManager>();
            this.Position = this.GetComponent<PositionStat>();
        }
    }
}