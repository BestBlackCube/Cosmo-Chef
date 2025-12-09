using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Script : MonoBehaviour
{
    public bool JumpPad = false;
    public float copy_timer = 0f;
    bool copyStart = false;
    public GameObject circle_copy;
    Rigidbody2D rigid2D;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            copyStart = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("autoMove"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid2D.velocity.x > 2f) rigid2D.velocity = new Vector3(2f, rigid2D.velocity.y, 0);
        rigid2D.AddForce(Vector2.right * 2f);

        if (copyStart)
        {
            if (copy_timer < 0.2f) copy_timer += Time.deltaTime;
            else
            {
                Instantiate(circle_copy, this.transform.position, Quaternion.identity);
                copy_timer = 0f;
            }
        }
    }
    void FixedUpdate()
    {
        if (JumpPad)
        {
            rigid2D.AddForce(Vector2.up * 22f * 22f);
            JumpPad = false;
        }
    }
}
