using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Script : MonoBehaviour
{
    public bool EndingDoor = false;
    [SerializeField] FoodTory_Script foodtory;
    [SerializeField] BlackScreen_Script black;
    [SerializeField] Player_Script player;
    [SerializeField] GameObject Guide;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerJump") ||
           col.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
        {
            EndingDoor = true;
            Guide.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        EndingDoor = false;
        Guide.SetActive(false);
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
            player.Dead_MoveLock = true;
            black.nextStage = true;
            this.gameObject.SetActive(false);
        }
    }
    public void potal_transform(int Count)
    {
        if(Count <= 1)
        {
            this.transform.position = new Vector3(0, -0.1f, 4);
        }
        else if(1 < Count && Count <= 3)
        {
            this.transform.position = new Vector3(0, -3.7f, 4);
        }
        else if(3 < Count)
        {
            this.transform.position = new Vector3(0, -1.1f, 4);
        }
    }
}
