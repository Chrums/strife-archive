using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatManager))]
[RequireComponent(typeof(ModifierManager))]
[RequireComponent(typeof(PriorityBehaviorManager))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    private Player owner = null;

    [SerializeField]
    private Board board = null;

    private ActionManager actionManager = new ActionManager();

    public Player Owner
    {
        get
        {
            return this.owner;
        }

        private set
        {
            this.owner = value;
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

    public ModifierManager Modifiers
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

    public void On<T>(Action<T> action) where T : class
    {
        this.actionManager.On(action);
    }

    public void Emit<T>(T value) where T : class
    {
        this.actionManager.Emit(value);
    }

    private void Awake()
    {
        this.Stats = this.GetComponent<StatManager>();
        this.Modifiers = this.GetComponent<ModifierManager>();
        this.Behaviors = this.GetComponent<PriorityBehaviorManager>();
    }

    private void Start()
    {
        this.Position = this.Stats.Get<PositionStat>();
    }
}
