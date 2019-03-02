using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaken
{
    public int amount;
    public DamageTaken(int value)
    {
        amount = value;
    }
}

public class DamageDealt
{
    public int amount;
    public DamageDealt(int value)
    {
        amount = value;
    }
}