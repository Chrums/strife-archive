using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatManager))]
[RequireComponent(typeof(PositionStat))]
[RequireComponent(typeof(PriorityBehaviorManager))]
public class Unit : MonoBehaviour
{
    [SerializeField]
    private Player player = null;

    [SerializeField]
    private Board board = null;

    private ActionManager actionManager = new ActionManager();

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

    public void On<T>(Action<T> action) where T : class
    {
        this.actionManager.On(action);
    }

    public void Emit<T>(T value) where T : class
    {
        this.actionManager.Emit(value);
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
