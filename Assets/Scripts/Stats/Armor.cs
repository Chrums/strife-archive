using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dexterity : Stat
{


    [SerializeField]
    private float m_Base = 10.0f;

    public float value { get { return m_Base; } private set { m_Base = value; } }

}

public class Armor : Stat
{

    [SerializeField]
    private float m_Base;

    public float value { get { return m_Base + unit.stats.Get<Dexterity>().value / 0.5f; } }

}
