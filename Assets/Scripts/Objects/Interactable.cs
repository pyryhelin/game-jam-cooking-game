using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract parent class for all interactable objects. Requires a box collider (trigger) to use

[RequireComponent(typeof(BoxCollider2D))]


//inherit the ObjectBaseclass: if an object is interacatable it must be also and object :D
public abstract class Interactable : ObjectBaseclass
{   
    private void Reset()
    {
        //GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // To override in the child class with functionality
    public abstract void Interact();


    // Set active interactive icon when enter collider from player controller
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().OpenInteracterableIcon();
        }
    }

    // Set active interactive icon when enter collider from player controller
    public virtual void OnTriggerExit2D(Collider2D collision)
    {
       
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().CloseInteracterableIcon();
        }
    }

}