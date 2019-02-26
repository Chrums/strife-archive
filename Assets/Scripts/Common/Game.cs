using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{

    public enum Phase
    {
        None,
        Draft,
        Battle
    }

    [SerializeField]
    private TextMeshProUGUI timeTextMesh;

    [SerializeField]
    private TextMeshProUGUI roundTextMesh;

    [SerializeField]
    private float m_DraftTime = 30.0f;

    [SerializeField]
    private float m_BattleTime = 60.0f;

    private float m_RemainingTime = 0.0f;

    public Phase phase { get; private set; } = Phase.Draft;

    private int round = 0;

    void Start()
    {
        BeginDraft();
    }
    
    void Update()
    {
        Debug.Log(phase);
        m_RemainingTime -= Time.deltaTime;
        timeTextMesh.text = Mathf.FloorToInt(m_RemainingTime).ToString();
        if (m_RemainingTime < 0.0f)
        {
            switch (phase)
            {
                case Phase.Draft:
                    BeginBattle();
                    return;
                case Phase.Battle:
                    BeginDraft();
                    return;
                default:
                    return;
            }
        }
    }

    void BeginDraft()
    {
        phase = Phase.Draft;
        m_RemainingTime = m_DraftTime;
    }

    void BeginBattle()
    {
        phase = Phase.Battle;
        m_RemainingTime = m_DraftTime;
    }

}
