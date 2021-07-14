using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{

    public KeyCode exitButton;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(exitButton)){
            OwnSceneManager.ExitMinigame();
        }
    }
}
