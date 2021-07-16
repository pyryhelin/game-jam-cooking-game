using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Interactable
{
    public override void Interact()
    {
        base.Interact();
        FillInventoy();
        //OwnSceneManager.LoadMinigame("Fridge");
    }

    public void FillInventoy(){
        Ingredient bottom = IngredientStore.getNewIngredientType(IngredientType.BottomBun);
        Ingredient patty = IngredientStore.getNewIngredientType(IngredientType.Patty);
        Ingredient top = IngredientStore.getNewIngredientType(IngredientType.TopBun);
        PlayerStats.AddToInventory(bottom);
        PlayerStats.AddToInventory(patty);
        PlayerStats.AddToInventory(top);
    }
}
