using UnityEngine;

public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        if (movement.dir.magnitude > 0.1f)
            movement.animator.SetBool("RunJump", true);  // Saltar corriendo o caminando
        else
            movement.animator.SetBool("IdleJump", true); // Saltar en idle

        movement.velocity.y = Mathf.Sqrt(movement.jumpHeight * -2f * movement.gravity);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.IsGrounded() && movement.velocity.y < 0)
        {
            ExitState(movement);
        }
    }

    void ExitState(MovementStateManager movement)
    {
        // Reseteamos los parámetros de salto
        movement.animator.SetBool("RunJump", false);
        movement.animator.SetBool("IdleJump", false);

        // Después de saltar, volvemos al estado correcto
        if (movement.dir.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                movement.SwitchState(movement.Run);
            else
                movement.SwitchState(movement.Walk);
        }
        else
        {
            movement.SwitchState(movement.Idle);
        }
    }

}
