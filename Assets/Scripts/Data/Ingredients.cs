using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
public enum IngredientType
{
    TopBun,
    BottomBun,
    Patty,

}

public class Ingredients : MonoBehaviour
{
    [SerializeField]
    private List<Ingredient> localIngredients = new List<Ingredient>();
    public Dictionary<IngredientType, Ingredient> ingredients = new Dictionary<IngredientType, Ingredient>();

    void Start()
    {
        foreach (var ingredient in localIngredients)
        {
            Debug.Log(ingredient.name);
            ingredients.Add(ingredient.type, ingredient);
        }

        KitchenSceneObjectReferences.ingredients = this;
    }
}



//define the possible properties ingredients.
[Serializable]
public class Ingredient : GeneralItem
{
    [SerializeField]
    private Sprite Icon;
    public Sprite icon { get { return Icon; } set { Icon = value; } }



    [SerializeField]
    private bool HasSpawanblePrefab;
    public bool hasSpawanblePrefab { get { return HasSpawanblePrefab; } set { HasSpawanblePrefab = value; } }


    [SerializeField]
    private GameObject SpawnablePrefab;
    public GameObject spawnablePrefab { get { return SpawnablePrefab; } set { SpawnablePrefab = value; } }

    [SerializeField]
    private string Name;
    public string name { get { return Name; } set { Name = value; } }


    [SerializeField]
    private IngredientType Type;
    public IngredientType type { get { return Type; } set { Type = value; } }


    //properites to defin cooking behivour:
    [SerializeField]
    private bool Cookable;
    public bool cookable { get { return Cookable; } set { Cookable = value; } }


    [SerializeField]
    private float CookTime;
    public float cookTime { get { return CookTime; } set { CookTime = value; } }



    //proprties to define slicing behaviour:
    [SerializeField]
    private bool Slicable;
    public bool slicable { get { return Slicable; } set { Slicable = value; } }


    //the amount of slices that needs to be cut:
    [SerializeField]
    private int NumberOfSlices;
    public int numberOfSlices { get { return NumberOfSlices; } set { NumberOfSlices = value; } }


    //if you want randomize the amount of sices, 
    //this value sets the maximum difference to the numberOfSlce
    //defined above. Must be at least 1 less than the numberofSlices
    [SerializeField]
    private int SliceAmountVariance;
    public int sliceAmountVariance { get { return SliceAmountVariance; } set { SliceAmountVariance = value; } }


    //percentage so value must be between 0 and 1;
    //task defines this value when correct processing (for exmple cutting, cooking) is done.
    [SerializeField]
    private float Quality;
    public float quality { get { return Quality; } set { Quality = value; } }

    public void SaveToStorage(){
        IngredientStore.sotredIngredients[this.type].Add(this);
    }

    public Ingredient GetCopyOfCurrent()
    {
        Ingredient copy = new Ingredient();
        //GetType().GetProperty(propertyName).GetValue(car, null);
        PropertyInfo[] properties = typeof(Ingredient).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            //Debug.Log(property.Name + ",\n" + GetType().GetProperty(property.Name).GetValue(this));
            property.SetValue(copy, GetType().GetProperty(property.Name).GetValue(this));
        }

        return copy;
    }

}