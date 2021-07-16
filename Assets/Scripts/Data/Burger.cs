using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Burger : GeneralItem {

    public List<Ingredient> burgerInredients = new List<Ingredient>();

    public GameObject burgerObject = new GameObject();

    public string name;
}