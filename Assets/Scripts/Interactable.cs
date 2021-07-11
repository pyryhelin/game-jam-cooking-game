using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract parent class for all interactable objects. Requires a box collider (trigger) to use

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // To override in the child class with functionality
    public abstract void Interact();


    // Set active interactive icon when enter collider from player controller
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OpenInteracterableIcon();
        }
    }

    // Set active interactive icon when enter collider from player controller
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().CloseInteracterableIcon();
        }
    }

}