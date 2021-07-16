using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLine : Interactable
{
    public override void Interact()
    {
        base.Interact();
        GetComponent<Renderer>().material.color = new Color(0, 255, 0);
        Debug.Log("fuck");
    }

}
