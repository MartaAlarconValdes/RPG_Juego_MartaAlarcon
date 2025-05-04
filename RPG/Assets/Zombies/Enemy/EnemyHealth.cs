using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    RagdollManager ragdollManager;
    [HideInInspector] public bool isDead;
    Animator animator;

    private void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
        }
    }

    void EnemyDeath()
    {
        ragdollManager.TriggerRagdoll();
        animator.SetBool("alive", false);

    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

}
