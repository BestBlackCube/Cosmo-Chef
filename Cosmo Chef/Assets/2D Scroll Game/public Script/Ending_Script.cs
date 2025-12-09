using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Script : MonoBehaviour
{
    public bool EndingDoor = false;
    [SerializeField] FoodTory_Script foodtory;
    [SerializeField] BlackScreen_Script black;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerJump") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
        {
            EndingDoor = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        EndingDoor = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && EndingDoor == true)
        {
            foodtory.stage_Panel.SetActive(false);
            foodtory.Clear_timer = 0f;
            black.nextStage = true;
            this.gameObject.SetActive(false);
        }
    }
}
