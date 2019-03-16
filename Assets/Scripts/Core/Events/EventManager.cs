using System;
using System.Collections;
using System.Collections.Generic;

namespace Fizz6.Core
{
    public class EventManager : EventManager<object>
    {
    }

    public class EventManager<T>
    {
        private Dictionary<Type, Action<T>> actions = new Dictionary<Type, Action<T>>();
        private Hashtable wrappers = new Hashtable();

        public void On<U>(Action<U> action) where U : T
        {
            Type key = typeof(U);
            Action<T> value = this.Wrap(action);
            if (!this.actions.ContainsKey(key))
            {
                this.actions[key] = value;
            }
            else
            {
                this.actions[key] += value;
            }

            this.wrappers.Add(action, value);
        }

        public void Off<U>(Action<U> action) where U : T
        {
            Action<T> value = this.wrappers[action] as Action<T>;
            this.actions[typeof(U)] -= value;
            this.wrappers.Remove(action);
        }

        public void Emit<U>(U value) where U : T
        {
            Type key = typeof(U);
            if (this.actions.ContainsKey(key))
            {
                this.actions[key]?.Invoke(value);
            }
        }

        private Action<T> Wrap<U>(Action<U> action) where U : T
        {
            return new Action<T>((T o) => action((U)o));
        }
    }
}