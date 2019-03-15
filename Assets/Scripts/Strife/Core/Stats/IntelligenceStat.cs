using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(ManaStat))]
    [RequireComponent(typeof(ManaRegenerationStat))]
    public class IntelligenceStat : Stat<IntelligenceStat>
    {
        [SerializeField]
        private float value = 0.0f;

        [SerializeField]
        private float manaPerIntelligence = 10.0f;

        [SerializeField]
        private float manaRegenerationPerIntelligence = 1.0f;

        private Modifier<float> manaBaseModifier = null;

        private Modifier<float> manaRegenerationBaseModifier = null;

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.manaBaseModifier.Modify((ref float manaBase) => manaBase += value * this.manaPerIntelligence);
                this.manaRegenerationBaseModifier.Modify((ref float manaRegenerationBase) => manaRegenerationBase += value * this.manaRegenerationPerIntelligence);
                this.value = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            ManaStat manaStat = this.GetComponent<ManaStat>();
            this.manaBaseModifier = manaStat.Base.Modify((ref float manaBase) => manaBase += this.value * this.manaPerIntelligence);
            ManaRegenerationStat manaRegenerationStat = this.GetComponent<ManaRegenerationStat>();
            this.manaRegenerationBaseModifier = manaRegenerationStat.Base.Modify((ref float manaRegenerationBase) => manaRegenerationBase += this.value * this.manaRegenerationPerIntelligence);
        }
    }
}