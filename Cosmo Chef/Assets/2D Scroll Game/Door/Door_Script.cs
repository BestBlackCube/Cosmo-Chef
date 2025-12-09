using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door_Script : MonoBehaviour
{
    public GameObject[] door;
    public int Count = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Count++;
        }
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        switch(Count)
        {
            case 1:
                if (door[Count - 1].transform.position.y > -5)
                    door[Count - 1].transform.position = new Vector3(door[Count - 1].transform.position.x, door[Count - 1].transform.position.y - 0.1f, 0);
                transform.position = new Vector3(168, 2, 0);
                break;
            case 2:
                if (door[Count - 1].transform.position.y > -5)
                    door[Count - 1].transform.position = new Vector3(door[Count - 1].transform.position.x, door[Count - 1].transform.position.y - 0.1f, 0);
                transform.position = new Vector3(189, 2, 0);
                break;
            case 3:
                if (door[Count - 1].transform.position.y > -5)
                    door[Count - 1].transform.position = new Vector3(door[Count - 1].transform.position.x, door[Count - 1].transform.position.y - 0.1f, 0);
                transform.position = new Vector3(181, -2, 0);
                break;
            case 4:
                if (door[Count - 1].transform.position.y > -5)
                    door[Count - 1].transform.position = new Vector3(door[Count - 1].transform.position.x, door[Count - 1].transform.position.y - 0.1f, 0);
                transform.position = new Vector3(168, 2, 0);
                break;
            default:
                break;
        }    
    }
}
