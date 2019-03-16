using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class StatManager : MonoBehaviour
    {
        private Dictionary<Type, StatBase> stats = new Dictionary<Type, StatBase>();

        public void Add<T>(T value) where T : StatBase
        {
            Type key = typeof(T);
            if (!this.stats.ContainsKey(key))
            {
                this.stats.Add(key, value);
            }
        }

        public void Remove<T>(T value) where T : StatBase
        {
            Type key = typeof(T);
            if (this.stats.ContainsKey(key))
            {
                this.stats.Remove(key);
            }
        }

        public T Get<T>() where T : StatBase
        {
            Type key = typeof(T);
            StatBase value;
            this.stats.TryGetValue(key, out value);
            return value as T;
        }
    }
}