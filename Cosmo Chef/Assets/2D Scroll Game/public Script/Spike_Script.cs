using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Script : MonoBehaviour
{
    Player_Script player;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Player") ||
            col.gameObject.layer == LayerMask.NameToLayer("PlayerJump") ||
            col.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
        {
            player.PlayerHit = true;
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.name == "Height_HitObject(Clone)")
        {
            transform.position += new Vector3(0, -6f, 0) * Time.deltaTime;
            if (transform.position.y < -12) Destroy(this.gameObject);
        }
        if (this.gameObject.name == "Width_HitObject(Clone)")
        {
            transform.position += new Vector3(-6f, 0, 0) * Time.deltaTime;
            if (transform.position.x < -17) Destroy(this.gameObject);
        }

    }
}
