using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTriggerBox_Script : MonoBehaviour
{
    [SerializeField] FoodDrop_Script drop;
    [SerializeField] FoodTory_Script foodtory;

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerJump") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
        {
            drop.Box_name = this.gameObject.name;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        drop.Box_name = "";
    }
}
