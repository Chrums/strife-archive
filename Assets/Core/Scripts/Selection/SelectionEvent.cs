using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = Fizz6.Core.Event;

namespace Fizz6.Core
{
    public class SelectionEvent : Event
    {
        public List<Selectable> Selectables
        {
            get;
            private set;
        }
        = null;

        public SelectionEvent(List<Selectable> selectables) : base()
        {
            this.Selectables = selectables;
        }
    }
}