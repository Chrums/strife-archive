using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class EventSystem : Singleton<EventSystem>
    {
        public static new EventManager Instance
        {
            get;
            private set;
        }
        = new EventManager();
    }
}