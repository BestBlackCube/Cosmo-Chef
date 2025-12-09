using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Script : MonoBehaviour
{
    public GameObject[] Food;
    string Object_name;
    bool nameinput = false;

    public FoodTory_Script food_tory;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Object_name = this.gameObject.name;
            nameinput = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nameinput)
        {
            switch(Object_name)
            {
                case "Food1_Object":
                    food_tory.food1_Count++;
                    break;
                case "Food2_Object":
                    food_tory.food2_Count++;
                    break;
                default:
                    break;
            }
            Object_name = "";
            Destroy(this.gameObject);
        }
    }
}
