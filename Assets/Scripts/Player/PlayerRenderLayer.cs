using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class PlayerRenderLayer : MonoBehaviour
{   
    private GameObject sceneManager;
    private SpriteRenderer sp;
    private SceneObjectManager som;
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("sceneObjectManager");
        som = sceneManager.GetComponent<SceneObjectManager>();          
        sp = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(sp);
        pos = gameObject.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(pos.y != this.transform.position.y){
            recalculateDrawingLayers();
        }
        pos = transform.position;
    }


    void recalculateDrawingLayers(){
        float playerSize = sp.sprite.rect.y / 2;
        float playerTruePos = transform.position.y + playerSize;
        GameObject[] objects = som.objectsOnScreen.ToArray();

        for(int i = 0; i < objects.Length; i++){
                GameObject tempObj = objects[i];
                SpriteRenderer tempSR = tempObj.GetComponent<SpriteRenderer>();
                
                if(tempSR.sprite.rect.y + tempObj.transform.position.y >= playerTruePos)
                    tempSR.sortingOrder = -1;
                else
                    tempSR.sortingOrder = 1;
            }
        }
}
