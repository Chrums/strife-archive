using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private Stats m_Stats = new Stats();
    public Stats stats { get { return m_Stats; } }

    private Dispatcher m_Dispatcher = new Dispatcher();

    [SerializeField]
    private Player m_Player;
    public Player player { get { return m_Player; } set { m_Player = player; } }

    [SerializeField]
    private Board m_Board;
    public Board board { get { return m_Board; } set { m_Board = value; } }

    [SerializeField]
    private Vector2Int m_Position;
    public Vector2Int position { get { return m_Position; } set { m_Position = value; transform.position = board.GetUnitWorldSpacePosition(this); } }

    private void Start()
    {
        transform.position = board.GetUnitWorldSpacePosition(this);
    }

    public void On<T>(Action<T> action) where T : class
    {
        m_Dispatcher.On(action);
    }

    public void Emit<T>(T item) where T : class
    {
        m_Dispatcher.Emit(item);
    }

}
