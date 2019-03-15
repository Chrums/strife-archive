using Fizz6.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Strife
{
    public abstract class RegenerationStat<D, T> : ScalableStat<D> where D : Stat<D> where T : ScalableStat<T>
    {
        [SerializeField]
        private float regenerationTime = 1.0f;

        private float regenerationTimer = 0.0f;

        public T ScalableStat
        {
            get;
            private set;
        }
        = null;

        public Modifiable<float> RegenerationTime
        {
            get;
            private set;
        }
        = new Modifiable<float>();

        public float RegenerationPerSecond
        {
            get
            {
                return this.Current / this.RegenerationTime;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            this.ScalableStat = this.GetComponent<T>();
            this.RegenerationTime.Initial = this.regenerationTime;
        }

        private void Update()
        {
            this.regenerationTimer += Time.deltaTime;
            if (this.regenerationTimer >= this.RegenerationTime)
            {
                this.ScalableStat.Current += this.Current;
                this.regenerationTimer -= this.RegenerationTime;
            }
        }
    }
}