using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenDoor_Script : MonoBehaviour
{
    [SerializeField] GameObject blackScreen;
    [SerializeField] Player_Script player;
    [SerializeField] Camera maincamera;
    public float Screen_timer = 0f;
    public bool kitchenDoor = false;
    public bool moveKitchen = false;
    public bool moveOutside = false;
    public bool DoorChange = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            kitchenDoor = true;
        }
        else
        {
            kitchenDoor = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(kitchenDoor == true)
        {
            if(DoorChange == false)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Screen_timer = 0f;
                    blackScreen.SetActive(true);
                    player.MoveRock = true;
                    moveKitchen = true;
                    DoorChange = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Screen_timer = 0f;
                    blackScreen.SetActive(true);
                    player.MoveRock = true;
                    moveOutside = true;
                    DoorChange = false;
                }
            }
            
            if (DoorChange == true)
            {
                if(moveKitchen == true)
                {
                    if (Screen_timer < 4f)
                    {
                        Screen_timer += Time.deltaTime;
                    }
                    else
                    {
                        player.transform.position = new Vector3(164, 16, 0);
                        maincamera.transform.position = new Vector3(164, 16, -10);
                        transform.position = new Vector3(164, 16, 0);
                        blackScreen.SetActive(false);
                        player.MoveRock = false;
                        moveKitchen = false;
                    }
                }
            }
            else
            {
                if(moveOutside == true)
                {
                    if (Screen_timer < 4f)
                    {
                        Screen_timer += Time.deltaTime;
                    }
                    else
                    {
                        player.transform.position = new Vector3(167, -2, 0);
                        maincamera.transform.position = new Vector3(167, -2, -10);
                        transform.position = new Vector3(167.25f, -2.05f, 0);
                        blackScreen.SetActive(false);
                        player.MoveRock = false;
                        moveOutside = false;
                    }
                }
            }
        }
    }
    
}
