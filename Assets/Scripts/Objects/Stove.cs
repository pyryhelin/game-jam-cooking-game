using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : Interactable
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

        OwnSceneManager.LoadMinigame("TestEmptyScene");
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

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

    }

}