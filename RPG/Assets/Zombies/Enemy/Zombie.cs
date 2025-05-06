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
        StartCoroutine(DieSequence());
    }

    private IEnumerator DieSequence()
    {
        if (agent.enabled)
        {
            agent.ResetPath();        // Detiene el movimiento
            agent.isStopped = true;   // Congela el agente
        }

        // Espera 0.05 segundos para asegurarte de que se detuvo del todo
        yield return new WaitForSeconds(0.05f);

        // Inicia animación de muerte
        animator.SetBool("alive", false);

        // Marcar como muerto para detener lógica del sistema
        base.Dying();

        // Desactiva agente después de la animación, o aquí si no es necesario
        if (agent.enabled)
            agent.enabled = false;
    }




}
