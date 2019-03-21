using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class ScalableStat<T> : Stat<ScalableStat<T>>
    {
        [SerializeField]
        protected float minimum = Mathf.NegativeInfinity;

        [SerializeField]
        protected float maximum = Mathf.Infinity;

        [SerializeField]
        protected float initialBase = 0.0f;

        [SerializeField]
        protected float initialMultiplier = 1.0f;

        [SerializeField]
        [Range(0.0f, 100.0f)]
        protected float initialPercentage = 100.0f;

        private float value = 0.0f;

        private float pool = 0.0f;

        public Modifiable<float> Base
        {
            get;
            private set;
        }
        = new Modifiable<float>();

        public Modifiable<float> Multiplier
        {
            get;
            private set;
        }
        = new Modifiable<float>();

        public float Pool
        {
            get
            {
                return this.pool;
            }

            private set
            {
                this.pool = Mathf.Clamp(value, this.minimum, this.maximum);
            }
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = Mathf.Clamp(value, this.minimum, this.Pool);
            }
        }

        protected override void Awake()
        {
            base.Awake();

            this.Base.Modify((ref float baseValue) => baseValue += this.initialBase);
            this.Base.OnChange += this.OnChange;

            this.Multiplier.Modify((ref float multiplierValue) => multiplierValue += this.initialMultiplier);
            this.Multiplier.OnChange += this.OnChange;

            this.Pool = initialBase * initialMultiplier;
            this.Value = this.Pool * initialPercentage;
        }

        private void OnChange()
        {
            float percentage = this.Value / this.Pool;
            this.Pool = this.Base * this.Multiplier;
            this.Value = this.Pool * percentage;
        }
    }
}