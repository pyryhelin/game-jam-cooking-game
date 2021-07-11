using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]

public abstract class ObjectBaseclass : MonoBehaviour
{   

    
    private SceneObjectManager som;
    
    //virtual keyword makes it possible to ovedrride in a class that inheritrs this baseclass
    //AND keep the behaviour described here.
    public virtual void Start()
    {
        //look for sceneObjectManager object in the scene and then from that object
        //get the SceneObjectManager. 
        som = GameObject.Find("sceneObjectManager").GetComponent<SceneObjectManager>();

        //add self to the list of objects on the screen.
        som.objectsOnScreen.Add(gameObject);

    }

}
