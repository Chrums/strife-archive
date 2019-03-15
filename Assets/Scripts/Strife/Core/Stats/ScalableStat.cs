using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public abstract class ScalableStat<T> : Stat<T> where T : Stat<T>
    {
        [SerializeField]
        private float initialBase = 0.0f;

        [SerializeField]
        private float initialMultiplier = 1.0f;

        [SerializeField]
        [Range(0.0f, 100.0f)]
        private float initialPercentage = 100.0f;

        private float current = 0.0f;

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

        public float Maximum
        {
            get;
            private set;
        }
        = 0.0f;

        public float Current
        {
            get
            {
                return this.current;
            }

            set
            {
                this.current = Mathf.Clamp(value, 0.0f, this.Maximum);
            }
        }

        protected float InitialPercentage
        {
            get
            {
                return this.initialPercentage;
            }

            set
            {
                this.initialPercentage = Mathf.Clamp(value, 0.0f, 100.0f);
            }
        }

        protected override void Awake()
        {
            this.Base.Initial = this.initialBase;
            this.Base.OnChange += this.OnChange;
            this.Multiplier.Initial = this.initialMultiplier;
            this.Multiplier.OnChange += this.OnChange;
            this.Maximum = this.Base * this.Multiplier;
            this.Current = this.Maximum * this.initialPercentage / 100.0f;
        }

        private void OnChange()
        {
            float ratio = this.Current == 0.0f && this.Maximum == 0.0f
                ? 1.0f
                : this.Current / this.Maximum;
            this.Maximum = this.Base * this.Multiplier;
            this.Current = ratio * this.Maximum;
        }
    }
}