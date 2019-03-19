using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance
        {
            get;
            private set;
        }
        = null;

        protected virtual void Awake()
        {
            if (Singleton<T>.Instance == null)
            {
                Singleton<T>.Instance = (T)this;
            }
            else
            {
                Debug.LogError($"Multiple {this.GetType().Name} instances allocated");
            }
        }

        protected virtual void OnDestroy()
        {
            if (this == Singleton<T>.Instance)
            {
                Singleton<T>.Instance = null;
            }
        }
    }
}