using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Grid))]
public class Board : MonoBehaviour
{
    private Grid grid = null;

    [SerializeField]
    private Vector2Int dimensions = new Vector2Int(10, 10);

    public List<Unit> Units
    {
        get;
        private set;
    }
    = new List<Unit>();

    public Vector2 CellToWorld(Vector2Int cell)
    {
        return this.grid.CellToWorld(new Vector3Int(cell.x, cell.y, 0));
    }

    public Vector2 CellToLocal(Vector2Int cell)
    {
        return this.grid.CellToLocal(new Vector3Int(cell.x, cell.y, 0));
    }

    public void AddUnit(Player player, Unit unit)
    {
        unit.Initialize(player, this);
        this.Units.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        this.Units.Remove(unit);
    }

    public bool IsCellEmpty(Vector2Int cell)
    {
        return this.Units.Aggregate(true, (bool value, Unit unit) => value || unit.Stats.Get<PositionStat>().Cell != cell);
    }

    private void Awake()
    {
        this.grid = this.GetComponent<Grid>();
    }
}
