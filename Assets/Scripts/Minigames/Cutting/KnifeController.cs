using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnifeController : MonoBehaviour
{
    //private Vector2 boxSize = GameObject.GetComponent<BoxCollider2D>().bounds.size;
    private Vector3 boxSize = new Vector2(0.01f, 1f);
    public KeyCode interactionKey;

    
    private void Start() {
        //add reference to the variable manager, its now easier to reference the player instance from everywhere
        //KitchenSceneObjectReferences.player = gameObject;
    }


    void Update()
    {
        if(Input.GetKeyDown(interactionKey))
        {
            CheckInteraction();
        }
    }

    // Raycasts to check for interaction
    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);
        
        foreach(RaycastHit2D rc in hits)
        {
            Debug.Log("shit balls");
            if(rc.transform.GetComponent<Interactable>())
            {
                Debug.Log("bitch cum");
                rc.transform.GetComponent<Interactable>().Interact();
                return;
            }
        }
        
    }



}
