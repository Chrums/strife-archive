using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(Grid))]
    public class Board : MonoBehaviour
    {
        private Grid grid = null;

        [SerializeField]
        private List<Unit> units = new List<Unit>();

        [SerializeField]
        private Vector2Int dimensions = new Vector2Int(10, 10);

        public List<Unit> Units
        {
            get
            {
                return this.units;
            }

            private set
            {
                this.units = value;
            }
        }

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
            return this.Units.Aggregate(true, (bool value, Unit unit) => value && unit.Position.Cell != cell);
        }

        public bool IsEnemyUnitInRange(Unit reference, float range)
        {
            return this.Units.Exists(unit => reference.Player != unit.Player && Vector2.Distance(reference.Position.Cell, unit.Position.Cell) <= range);
        }

        public Vector2Int GetClosestAvailableCell(Vector2 target)
        {
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            Vector2Int cell = new Vector2Int(Mathf.RoundToInt(target.x), Mathf.RoundToInt(target.y));
            queue.Enqueue(cell);
            return this.GetClosestAvailableCellHelper(queue, new HashSet<Vector2Int>());
        }

        private Vector2Int GetClosestAvailableCellHelper(Queue<Vector2Int> queue, HashSet<Vector2Int> visited)
        {
            Vector2Int cell = queue.Dequeue();
            if (this.IsCellEmpty(cell))
            {
                return cell;
            }
            else
            {
                visited.Add(cell);

                Vector2Int left = cell + Vector2Int.left;
                if (!visited.Contains(left))
                {
                    queue.Enqueue(left);
                }

                Vector2Int up = cell + Vector2Int.up;
                if (!visited.Contains(up))
                {
                    queue.Enqueue(up);
                }

                Vector2Int right = cell + Vector2Int.right;
                if (!visited.Contains(right))
                {
                    queue.Enqueue(right);
                }

                Vector2Int down = cell + Vector2Int.down;
                if (!visited.Contains(down))
                {
                    queue.Enqueue(down);
                }

                return this.GetClosestAvailableCellHelper(queue, visited);
            }
        }

        public Vector2Int GetFurthestAvailableCellInRange(Vector2 reference, Vector2 target, float range = Mathf.Infinity)
        {
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            Vector2 position = (reference - target).normalized * range;
            Vector2Int initial = new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
            queue.Enqueue(initial);
            return this.GetFurthestAvailableCellInRangeHelper(target, range, queue, new HashSet<Vector2Int>());
        }

        private Vector2Int GetFurthestAvailableCellInRangeHelper(Vector2 target, float range, Queue<Vector2Int> queue, HashSet<Vector2Int> visited)
        {
            Vector2Int cell = queue.Dequeue();
            if (this.IsCellEmpty(cell) && Vector2.Distance(target, cell) <= range)
            {
                return cell;
            }
            else
            {
                visited.Add(cell);

                Vector2Int left = cell + Vector2Int.left;
                if (!visited.Contains(left) && Vector2.Distance(target, left) <= range)
                {
                    queue.Enqueue(left);
                }

                Vector2Int up = cell + Vector2Int.up;
                if (!visited.Contains(up) && Vector2.Distance(target, up) <= range)
                {
                    queue.Enqueue(up);
                }

                Vector2Int right = cell + Vector2Int.right;
                if (!visited.Contains(right) && Vector2.Distance(target, right) <= range)
                {
                    queue.Enqueue(right);
                }

                Vector2Int down = cell + Vector2Int.down;
                if (!visited.Contains(down) && Vector2.Distance(target, down) <= range)
                {
                    queue.Enqueue(down);
                }

                return this.GetFurthestAvailableCellInRangeHelper(target, range, queue, visited);
            }
        }

        private void Awake()
        {
            this.grid = this.GetComponent<Grid>();
        }
    }
}