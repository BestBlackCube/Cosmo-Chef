using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Script : MonoBehaviour
{
    //public GameObject Food;
    string Object_name;
    bool nameinput = false;
    float Destroy_timer = 0;

    FoodTory_Script food_tory;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerJump") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
        {
            Object_name = this.gameObject.name;
            nameinput = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        food_tory = FindObjectOfType<FoodTory_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if(nameinput)
        {
            switch(Object_name)
            {
                case "Food1_Object(Clone)":
                    food_tory.food1_Count++;
                    break;
                case "Food2_Object(Clone)":
                    food_tory.food2_Count++;
                    break;
                case "Food3_Object(Clone)":
                    food_tory.food3_Count++;
                    break;
                default:
                    break;
            }
            Object_name = "";
            Destroy(this.gameObject);
        }
        if (Destroy_timer < 5f) Destroy_timer += Time.deltaTime;
        else Destroy(this.gameObject);
    }
}
