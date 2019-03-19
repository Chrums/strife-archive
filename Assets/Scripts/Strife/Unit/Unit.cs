using Fizz6.Core;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(PriorityBehaviorManager))]
    [RequireComponent(typeof(StatManager))]
    public class Unit : MonoBehaviour
    {
        public Player Player
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

        public StatManager Stats
        {
            get;
            private set;
        }
        = null;

        public void Initialize(Player player)
        {
            this.Player = player;
        }

        protected virtual void Awake()
        {
            this.Behaviors = this.GetComponent<PriorityBehaviorManager>();
            this.Stats = this.GetComponent<StatManager>();
        }
    }
}