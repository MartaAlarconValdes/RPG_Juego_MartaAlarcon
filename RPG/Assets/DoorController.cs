using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    private CollectibleObject collectibleObject;
    public Animator animator;



    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectibleObject.isCollected == true)
            {
                animator.SetBool("IsOpen", true);
            }
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        collectibleObject = FindObjectOfType<CollectibleObject>(); 
    }



}
