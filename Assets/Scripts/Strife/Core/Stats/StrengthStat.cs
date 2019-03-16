using Fizz6.Core;
using UnityEngine;

namespace Fizz6.Strife
{
    [RequireComponent(typeof(HealthStat))]
    [RequireComponent(typeof(HealthRegenerationStat))]
    public class StrengthStat : Stat<StrengthStat>
    {
        [SerializeField]
        private float value = 0.0f;

        [SerializeField]
        private float healthPerStrength = 10.0f;

        [SerializeField]
        private float healthRegenerationPerStrength = 1.0f;

        private Modifiable<float>.Modifier healthBaseModifier = null;

        private Modifiable<float>.Modifier healthRegenerationBaseModifier = null;

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.healthBaseModifier.Modify((ref float healthBase) => healthBase += value * this.healthPerStrength);
                this.healthRegenerationBaseModifier.Modify((ref float healthRegenerationBase) => healthRegenerationBase += value * this.healthRegenerationPerStrength);
                this.value = value;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            HealthStat healthStat = this.GetComponent<HealthStat>();
            this.healthBaseModifier = healthStat.Base.Modify((ref float healthBase) => healthBase += this.value * this.healthPerStrength);
            HealthRegenerationStat healthRegenerationStat = this.GetComponent<HealthRegenerationStat>();
            this.healthRegenerationBaseModifier = healthRegenerationStat.Base.Modify((ref float healthRegenerationBase) => healthRegenerationBase += this.value * this.healthRegenerationPerStrength);
        }
    }
}