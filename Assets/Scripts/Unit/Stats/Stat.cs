using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public abstract class Stat : MonoBehaviour
{
    public Unit Unit
    {
        get;
        private set;
    }

    private void Awake()
    {
        this.Unit = this.GetComponent<Unit>();
        Unit.Stats.Add(this);
    }
}
