using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class Board : MonoBehaviour
{

    //private class Units
    //{

    //    private Board m_Board;

    //    private List<Unit> m_Units = new List<Unit>();

    //    public Units(Board board)
    //    {
    //        m_Board = board;
    //    }

    //    public void Add(GameObject unitPrefab, Vector2Int position)
    //    {
    //        if (!m_Board.IsPositionOccupied(position))
    //        {
    //            GameObject gameObject = Instantiate(unitPrefab);
    //            Unit unit = gameObject.GetComponent<Unit>();
    //            m_Units.Add(unit);
    //        }
    //    }

    //    public void Remove(Unit unit)
    //    {
    //        m_Units.Remove(unit);
    //    }

    //    public List<Unit> ToList()
    //    {
    //        return m_Units;
    //    }

    //}

    [SerializeField]
    private Player m_Player;
    public Player player { get { return m_Player; } set { m_Player = player; } }

    private Grid m_Grid;

    [SerializeField]
    private List<Unit> m_Units = new List<Unit>();
    public List<Unit> units { get { return m_Units; } }

    private void Awake()
    {
        m_Grid = GetComponent<Grid>();
    }

    public bool IsPositionOccupied(Vector2Int position)
    {
        return m_Units.Aggregate(false, (bool isOccupied, Unit unit) => isOccupied || unit.position == position);
    }

    public Vector2 GetUnitBoardSpacePosition(Unit unit)
    {
        return m_Grid.CellToLocal(new Vector3Int(unit.position.x, unit.position.y, 0));
    }

    public Vector2 GetUnitWorldSpacePosition(Unit unit)
    {
        return m_Grid.CellToWorld(new Vector3Int(unit.position.x, unit.position.y, 0));
    }

    public Unit GetNearestEnemyUnit(Unit unit)
    {
        return m_Units
            .Where((Unit other) => unit.player != other.player)
            .Aggregate(null, (Unit current, Unit next) => current == null ? next : Vector2.Distance(unit.position, current.position) < Vector2.Distance(unit.position, next.position) ? current : next);
    }

    public Unit GetFurthestEnemyUnit(Unit unit)
    {
        return m_Units
            .Where((Unit other) => unit.player != other.player)
            .Aggregate(null, (Unit current, Unit next) => current == null ? next : Vector2.Distance(unit.position, current.position) < Vector2.Distance(unit.position, next.position) ? next : current);
    }

}
