using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    [RequireComponent(typeof(Collider))]
    public class Selectable : MonoBehaviour
    {
        protected virtual void Awake()
        {
            SelectionSystem.Instance.Add(this);
        }

        protected virtual void OnDestroy()
        {
            SelectionSystem.Instance.Remove(this);
        }
    }

}