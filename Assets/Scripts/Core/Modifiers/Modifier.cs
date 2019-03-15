using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public delegate void Transformer<T>(ref T value);

    public class Modifier<T> where T : new()
    {
        private Modifiable<T> modifiable = null;

        private Transformer<T> transform = null;

        public Modifier(Modifiable<T> modifiable, Transformer<T> transform)
        {
            this.modifiable = modifiable;
            this.transform = transform;
        }

        public Transformer<T> Transform
        {
            get
            {
                return this.transform;
            }

            set
            {
                this.Modify(value);
            }
        }

        public void Modify(Transformer<T> transform)
        {
            this.transform = transform;
            this.modifiable.Calculate();
        }

        public void Destroy()
        {
            this.modifiable.Destroy(this);
        }
    }
}