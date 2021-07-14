using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Interactable
{

    public override void Interact()
    {
        base.Interact();
        OwnSceneManager.LoadMinigame("AssemblyGame");
    }
    //doesnt need any content for now
}
