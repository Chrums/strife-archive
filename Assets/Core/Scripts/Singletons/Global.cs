using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fizz6.Core
{
    public class Global : Singleton<Global>
    {
        public EventManager Events
        {
            get;
            private set;
        }
        = new EventManager();
    }
}