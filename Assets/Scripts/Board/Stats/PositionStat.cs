using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionStat : Stat<PositionStat>
{
    [SerializeField]
    private Vector2Int? cell = null;

    public Vector2Int? Cell
    {
        get
        {
            return this.cell;
        }

        set
        {
            this.cell = value;
        }
    }
}
