using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAutoMove : MonoBehaviour
{
    public Player_Script player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(!player.Player_Move) player.GetComponent<Player_Script>().Player_Move = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
