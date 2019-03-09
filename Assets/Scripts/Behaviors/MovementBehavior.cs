using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpeedStat))]
public class MovementBehavior : PriorityBehavior
{
    private SpeedStat speedStat = null;

    [SerializeField]
    private AnimationCurve curve = AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);

    private Vector2 sourcePosition = Vector2.zero;

    private Vector2 targetPosition = Vector2.zero;

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

    public Vector2 Target
    {
        get
        {
            return this.targetPosition;
        }

        protected set
        {
            this.sourcePosition = this.transform.position;
            this.travelTime = Vector2.Distance(this.sourcePosition, value) / this.speedStat.Current;
            this.travelTimer = 0.0f;
            this.targetPosition = value;
        }
    }

    public Board Board
    {
        get;
        protected set;
    }
    = null;

    public override bool Query()
    {
        return this.speedStat.Current != 0.0f;
    }

    public override void Activate()
    {
        base.Activate();
        this.Target = new Vector2(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
        TestStat ts = new TestStat();
    }

    public override void Pump()
    {
        base.Pump();
        if (this.travelTime == Mathf.Infinity)
        {
            this.Yield();
        }

        this.travelTimer += Time.deltaTime;
        float t = this.travelTimer / this.travelTime;
        this.transform.position = Vector2.Lerp(this.sourcePosition, this.Target, this.curve.Evaluate(t));
        if (t >= 1.0f)
        {
            this.Yield();
        }
    }

    protected override void Awake()
    {
        base.Awake();
        this.speedStat = this.GetComponent<SpeedStat>();
    }
}
