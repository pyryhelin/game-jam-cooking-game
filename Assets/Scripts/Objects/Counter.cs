using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : Interactable
{

    List<Ingredient> test = new List<Ingredient>();
    public override void Interact()
    {
        base.Interact();
        OwnSceneManager.LoadMinigame("AssemblyGame");
        // Ingredient t = IngredientStore.getNewIngredientType(IngredientType.BottomBun);
        // Debug.Log(t.name);
        // t.name += (test.Count + 1).ToString();
        // test.Add(t);
        // Debug.Log("First " + test[0].name);
        // Debug.Log("Latest " + t.name);
    }
    //doesnt need any content for now
}
