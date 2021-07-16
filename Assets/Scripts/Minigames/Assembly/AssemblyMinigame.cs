using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AssemblyMinigame : MonoBehaviour
{
    public Canvas sceneCanvas;
    
    [SerializeField]
    public List<Ingredient> ingredients;

    private Ingredient[] ingArr;
    public KeyCode startKey;
    public KeyCode dropKey;

    private bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(sceneCanvas.GetComponent<RectTransform>().rect.height);
        Debug.Log(sceneCanvas.GetComponent<RectTransform>().rect.width);
        /*
        ingredients.Add(IngredientStore.getNewIngredientType(IngredientType.BottomBun));
        ingredients.Add(IngredientStore.getNewIngredientType(IngredientType.Patty));
        ingredients.Add(IngredientStore.getNewIngredientType(IngredientType.TopBun));
        ingArr = ingredients.ToArray();*/
    }


    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
            {if(Input.GetKeyDown(startKey))
                GameStart();
            return;}
        
        if(Input.GetKeyDown(dropKey)){
            Ingredient spawnable = PlayerStats.GetSelectedSoltIngredient();
            if(spawnable == null)
                return;
            Instantiate(spawnable.spawnablePrefab, new Vector3(0,0,11), new Quaternion(0,0,0,0));
        }

    }

    private void GameStart(){
        gameStarted = true;
    }

}
