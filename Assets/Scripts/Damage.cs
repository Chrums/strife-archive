using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage
{

    public Unit by { get; private set; }
    public Unit to { get; private set; }
    public float amount { get; private set; }

    public Damage(Unit by, Unit to, float amount)
    {
        this.by = by;
        this.to = to;
        Armor armor = to.stats.Get<Armor>();
        this.amount = amount - amount * (armor.value / 100.0f);
    }

}