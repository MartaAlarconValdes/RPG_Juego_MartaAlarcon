using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingState : MovementBaseState
{

    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        throw new System.NotImplementedException();
    }

   
}
