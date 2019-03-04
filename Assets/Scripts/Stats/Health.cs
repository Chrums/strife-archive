using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Stat
{

    [SerializeField]
    private float m_Base;

    [SerializeField]
    private float m_Current;

    protected override void Awake()
    {
        base.Awake();
        Reset();
        unit.On<Damage>(OnDamage);
    }

    private void Update()
    {
        if (m_Current <= 0)
        {
            unit.gameObject.SetActive(false);
        }
    }

    public override void Reset()
    {
        base.Reset();
        m_Current = m_Base;
    }

    private void OnDamage(Damage damage)
    {
        if (damage.to == unit)
        {
            m_Current -= damage.amount;
        }
    }

}
