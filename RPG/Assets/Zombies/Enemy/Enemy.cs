using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    Patrol = 0,
    Chase = 1,
    Attack = 2,
    Flee = 3,
    Die = 4
}
public class Enemy : MonoBehaviour
{
    public States state;
    public float followDistance;
    public float attackDistance;
    public bool alive = true;

    public Transform target;
    public float distance;


    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(CalculateDistance());
    }
    private void LateUpdate()
    {
        CheckState();
    }
    public void CheckState()
    {
        if (!alive) return;
        switch (state)
        {
            case States.Patrol:
                Patrolling();
                break;
            case States.Chase:
                Chasing();
                break;
            case States.Attack:
                Attacking();
                break;
            case States.Flee:
                Fleeing();
                break;
            case States.Die:
                Dying();
                break;
        }
    }

    public void ChangeState(States s)
    {
        switch (s)
        {
            case States.Patrol:
                break;
            case States.Chase:
                break;
            case States.Attack:
                break;
            case States.Flee:
                break;
            case States.Die:
                alive = false;
                break;
        }
        state = s;
    }

    public virtual void Patrolling()
    {
        if (distance < followDistance) 
        {
            ChangeState(States.Chase);
        }
    }
    public virtual void Chasing()
    {
        if (distance < attackDistance)
        {
            ChangeState(States.Attack);
        }
        else if (distance > followDistance + 0.5f) 
        {
            ChangeState(States.Patrol);
        }

    }

    public virtual void Attacking() 
    { 
        if (distance > attackDistance + .25f)
        {
            ChangeState (States.Chase);
        }
    }
    public virtual void Fleeing() { }
    public virtual void Dying() { }

    IEnumerator CalculateDistance()
    {
        while (alive)
        {
            distance = Vector3.Distance(transform.position, target.position);
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, followDistance);

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
