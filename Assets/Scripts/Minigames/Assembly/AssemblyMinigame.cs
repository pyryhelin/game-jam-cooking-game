using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AssemblyMinigame : MonoBehaviour
{
    public Canvas sceneCanvas;

    [Serializable]
    public struct Ingredient 
    {
        public string name;
        public GameObject ingredient;
    }

    public List<Ingredient> ingredients;

    public KeyCode startKey;

    public KeyCode dropKey;
 

    private bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(sceneCanvas.GetComponent<RectTransform>().rect.height);
        Debug.Log(sceneCanvas.GetComponent<RectTransform>().rect.width);

    }


    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
            if(Input.GetKeyDown(startKey))
                GameStart();
        

    }

    private void GameStart(){
        gameStarted = true;
    }

}
