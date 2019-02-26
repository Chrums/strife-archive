using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public delegate void OnDamageDealt(int amount);
    public delegate void OnDamageTaken(int amount);

    private OnDamageDealt m_OnDamageDealt;
    public OnDamageDealt onDamageDealt { get { return m_OnDamageDealt; } set { m_OnDamageDealt = value; } }

    private OnDamageDealt m_OnDamageTaken;
    public OnDamageDealt onDamageTaken { get { return m_OnDamageTaken; } set { m_OnDamageTaken = value; } }

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

}
