using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float damage = 10f;
    private PlayerHealth playerHealth;
    private bool playerInRange = false;

    public Collider attackTrigger;

    private void Start()
    {
        attackTrigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            playerHealth = other.GetComponent<PlayerHealth>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerHealth = null;
        }
    }

    public void DealDamage()
    {
        if (playerInRange && playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
