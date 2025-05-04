using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{

    public float currentMoveSpeed;
    public float walkSpeed = 3, walkBackSpeed = 2;
    public float runSpeed = 7, runBackSpeed = 5;
    public float crouchSpeed = 2, crouchBackSpeed = 1;



    [HideInInspector] public Vector3 dir;
    public float hzInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    public float jumpHeight = 1.5f; // ajusta a gusto
    public float gravity = -9.81f;
    public Vector3 velocity;

    public JumpState Jump = new JumpState();
    public MovementBaseState currentState;
    public IdleState Idle = new IdleState();
    public WalkState Walk = new WalkState();
    public RunState Run = new RunState();
    public CrouchingState Crouch = new CrouchingState();

    [HideInInspector] public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
        Gravity();

        animator.SetFloat("hzInput", hzInput);
        animator.SetFloat("vInput", vInput);

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);

    }
    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;
        controller.Move(dir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    public bool IsGrounded()
    {

        return controller.isGrounded;

    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePos, controller.radius - 0.05f);
    }
}
