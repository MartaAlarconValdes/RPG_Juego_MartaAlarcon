using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("Running", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        throw new System.NotImplementedException();
    }
}
