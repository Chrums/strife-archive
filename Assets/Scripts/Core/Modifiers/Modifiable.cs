using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class Modifiable<T> where T : new()
    {
        public static implicit operator T(Modifiable<T> modifiable)
        {
            return modifiable.Value;
        }

        private T initial = default;

        private List<Modifier<T>> modifiers = new List<Modifier<T>>();

        public delegate void OnChangeDelegate();
        public OnChangeDelegate OnChange = default;

        public T Value
        {
            get;
            private set;
        }
        = default;

        public T Initial
        {
            get
            {
                return this.initial;
            }

            set
            {
                this.initial = value;
                this.Calculate();
            }
        }

        public Modifiable(T initial = default)
        {
            this.Initial = initial;
            this.Value = initial;
        }

        public Modifier<T> Modify(Transformer<T> transform)
        {
            Modifier<T> modifier = new Modifier<T>(this, transform);
            this.modifiers.Add(modifier);
            this.Calculate();
            return modifier;
        }

        public void Destroy(Modifier<T> wrapper)
        {
            this.modifiers.Remove(wrapper);
            this.Calculate();
        }

        public void Calculate()
        {
            T value = this.Initial;
            this.modifiers.ForEach(modifier => modifier.Transform(ref value));
            this.Value = value;
            this.OnChange?.Invoke();
        }
    }
}