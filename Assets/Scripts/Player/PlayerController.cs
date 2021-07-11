using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls player interactables

// @holly, we could probably add more player stuff to this, otherwise i can rename it
// smth to do with the colliders, lmk what u think :)))


public class PlayerController : MonoBehaviour
{
    public GameObject interactIcon;
    private Vector2 boxSize = new Vector2(0.1f, 1f); // basically only lets player interact with objects to the front, might need to change

    public KeyCode interactionKey;

    void Update()
    {
        // Guess we can make a different checkInteraction thing if we need
        // slightly different button input for different things
        if(Input.GetKeyDown(interactionKey))
        {
            CheckInteraction();
        }
    }

    // Set active interactive icon when enter collider
    public void OpenInteracterableIcon()
    {
        interactIcon.SetActive(true);
    }

    // Set active interactive icon when enter collider
    public void CloseInteracterableIcon()
    {
        interactIcon.SetActive(false);
    }

    // Raycasts to check for interaction
    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);
        
        foreach(RaycastHit2D rc in hits)
        {
            if(rc.transform.GetComponent<Interactable>())
            {
                rc.transform.GetComponent<Interactable>().Interact();
                return;
            }
        }
        
    }



}
