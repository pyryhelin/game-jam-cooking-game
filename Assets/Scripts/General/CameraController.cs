using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Script where we define the behaviour of the camera. 
    private void Start() {
        //add reference to the variable manager, its now easier to reference this instance from everywhere
        KitchenSceneObjectReferences.camera = gameObject;
    }


}
