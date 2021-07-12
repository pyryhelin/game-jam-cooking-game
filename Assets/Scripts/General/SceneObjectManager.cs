using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneObjectManager : MonoBehaviour
{   

    public List<GameObject> objectsOnScreen;
    // Start is called before the first frame update
    void Awake(){
        objectsOnScreen = new List<GameObject>();
    }

    void Start(){
        OwnSceneManager.Start();
    }

}
