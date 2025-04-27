using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Zombie : Enemy
{

    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public override void Patrolling()
    {
        base.Patrolling();
        animator.SetBool("chasing", false);
        animator.SetBool("attacking", false);

        agent.SetDestination(transform.position);
    }
    public override void Chasing()
    {
        base.Chasing();
        animator.SetBool("chasing", true);
        animator.SetBool("attacking", false);

        agent.SetDestination(target.position);
    }
    public override void Attacking()
    {
        base.Attacking();
        animator.SetBool("chasing", false);

        animator.SetBool("attacking", true);

        Vector3 direction =(target.position -transform.position).normalized;
        direction.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    public override void Fleeing()
    {
        base.Fleeing(); 
        agent.SetDestination(-transform.position);
    }
    public override void Dying()
    {
        animator.SetBool("alive", false);
        base.Dying();
        agent.enabled = false;
    }


}
