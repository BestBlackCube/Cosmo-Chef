using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public Player_Script player;
    public Load_Script load;
    int Count = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            player.GetComponent<Player_Script>().JumpPad = true;
            Count++;
        }
        if(col.gameObject.layer == LayerMask.NameToLayer("copy"))
        {
            load.GetComponent<Load_Script>().JumpPad = true;
        }
    }
    void FixedUpdate()
    {
        switch (Count)
        {
            case 0:
                transform.position = new Vector3(29, -2, 0);
                break;
            case 1:
                transform.position = new Vector3(34, 1, 0);
                break;
            case 2:
                transform.position = new Vector3(95, -2, 0);
                break;
            case 3:
                transform.position = new Vector3(102, 1, 0);
                break;
            case 4:
                transform.position = new Vector3(109, 4, 0);
                break;
            case 5:
                gameObject.SetActive(false);
                break;
            default:

                break;
        }
    }
}
