using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjectManager : MonoBehaviour
{   

    public List<GameObject> objectsOnScreen;
    // Start is called before the first frame update
    void Awake(){
        objectsOnScreen = new List<GameObject>();
    }
}
