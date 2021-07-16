using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIElements.inventory = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
