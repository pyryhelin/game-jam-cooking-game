using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Example implementation of interactable child class, just override Interact with
// functionality of the trigger.

// @holly, I just made a simple on/off thing with the debug logs, just to show
// how it works, just attatch the script to an object and make sure it has
// a collider with trigger on


[RequireComponent(typeof(SpriteRenderer))]
public class ExampleInteraction : Interactable
{

    public bool isOn = false;
    
    public void StartUsing()
    {
        Debug.Log("On");
    }


    public void StopUsing()
    {
        Debug.Log("Off");
    }


    public override void Interact()
    {
        if(isOn)
        {
            isOn = !isOn;
            StopUsing();
        }
        else
        {
            isOn = !isOn;
            StartUsing();
        }
    }

}
