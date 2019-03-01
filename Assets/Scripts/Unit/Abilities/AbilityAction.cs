using UnityEngine;
using System.Collections;

public abstract class AbilityAction : UnitAction
{

    [SerializeField]
    private int m_Charge;
    public int charge { get { return m_Charge; } protected set { m_Charge = value; } }

    [SerializeField]
    private int m_Cost;
    public int cost { get { return m_Cost; } protected set { m_Cost = value; } }
    
    public AbilityAction() : base()
    {
        priority = 0.0f;
    }

    public override bool Query()
    {
        return m_Charge > m_Cost;
    }

}
