using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject somObj = GameObject.Find("sceneObjectManager");
        somObj.GetComponent<SceneObjectManager>().objectsOnScreen.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
