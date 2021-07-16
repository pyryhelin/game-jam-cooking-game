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

    public KeyCode finishBurger;
    private bool gameStarted = false;

    private GameObject burgerObjct;
    Burger burger;
    // Start is called before the first frame update
    void Start()
    {
        burger = new Burger();
        burger.name = "Ass";
    }


    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
            {if(Input.GetKeyDown(startKey))
                GameStart();
            return;}
        
        if(Input.GetKeyDown(dropKey)){
            
        }

    }

    private void GameStart(){
        gameStarted = true;
    }

    private void GetNextDroppable(){
        Ingredient spawnable = PlayerStats.GetSelectedSoltIngredient();
            if(spawnable == null)
                return;

        GameObject ing =  Instantiate(spawnable.spawnablePrefab, new Vector3(0,0,11), new Quaternion(0,0,0,0));
    }

}
