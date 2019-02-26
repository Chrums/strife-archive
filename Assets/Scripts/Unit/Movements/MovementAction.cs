using UnityEngine;
using System.Collections;

public abstract class MovementAction : UnitAction
{
    
    public MovementAction() : base()
    {
        priority = 1.0f;
    }

    public override bool Query()
    {
        return true;
    }

}
