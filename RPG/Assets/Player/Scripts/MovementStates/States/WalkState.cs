using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.animator.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        throw new System.NotImplementedException();
    }
}
