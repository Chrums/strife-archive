using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizz6.Core
{
    public interface IPriorityBehavior
    {
        float Priority
        {
            get;
        }

        bool IsActive
        {
            get;
        }

        bool Query();

        void Pump();

        void Activate();

        void Deactivate();

        bool Interrupt(PriorityBehavior priorityBehavior);
    }
}
