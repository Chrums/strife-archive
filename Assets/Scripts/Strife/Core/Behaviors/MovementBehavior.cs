using Fizz6.Core;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(SpeedStat))]
    public class MovementBehavior : PriorityBehavior
    {
        private SpeedStat speedStat = null;

        [SerializeField]
        private AnimationCurve curve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);

        private Vector2 sourcePosition = Vector2.zero;

        private Vector2? targetPosition = null;

        private float travelTime = 0.0f;

        private float travelTimer = 0.0f;

        public MovementBehavior()
        {
            this.Priority = 0.6f;
        }

        public AnimationCurve Curve
        {
            get
            {
                return this.curve;
            }

            protected set
            {
                this.curve = value;
            }
        }

        public Vector2? Target
        {
            get
            {
                return this.targetPosition;
            }

            protected set
            {
                this.sourcePosition = this.transform.position;
                this.targetPosition = value;
                this.travelTime = value.HasValue
                    ? Vector2.Distance(this.sourcePosition, value.Value) / this.speedStat.Current
                    : 0.0f;
                this.travelTimer = 0.0f;
            }
        }

        public override bool Query()
        {
            return this.speedStat.Current != 0.0f;
        }

        public override void Activate()
        {
            base.Activate();
            this.Target = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        }

        public override void Pump()
        {
            base.Pump();
            if (!this.Target.HasValue)
            {
                this.Yield();
                return;
            }

            if (this.travelTime == 0.0f || this.travelTime == Mathf.Infinity)
            {
                this.Yield();
                return;
            }

            this.travelTimer += Time.deltaTime;
            float t = Mathf.Clamp(this.travelTimer / this.travelTime, 0.0f, 1.0f);
            this.transform.position = Vector2.Lerp(this.sourcePosition, this.Target.Value, this.curve.Evaluate(t));

            if (t == 1.0f)
            {
                this.Yield();
                return;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            this.speedStat = this.GetComponent<SpeedStat>();
        }
    }
}