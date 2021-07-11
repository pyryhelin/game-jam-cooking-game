using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInScene : MonoBehaviour
{
    //this script keeps object alive even if the scene changes.
    void Awake() {
        DontDestroyOnLoad(this.gameObject);    
        Debug.Log(Application.persistentDataPath);
    }
}
