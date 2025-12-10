using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    [SerializeField] FoodDrop_Script drop;
    [SerializeField] Ending_Script door;

    [SerializeField] Rigidbody2D rigid2D;
    [SerializeField] CapsuleCollider2D topBox2D;
    [SerializeField] BoxCollider2D bottomBox2D;
    [SerializeField] Animator animator;
    [SerializeField] Image Hpbar;
    [SerializeField] GameObject gameOver;
    [SerializeField] string ObjectName;
    
    bool Left = false;
    bool LeftStart = false;
    bool Right = false;
    bool RightStart = false;

    public bool PlayerHit = false;
    [SerializeField] bool OneHit = true;
    public bool Dead_MoveLock = false;

    [SerializeField] bool JumpStart = false;
    [SerializeField] bool Jump = false;

    [SerializeField] int nowHp;
    [SerializeField] int MaxHp;

    //[SerializeField] float movePower = 20f;
    [SerializeField] float jumpPower = 20f;
    float Hit_timer = 0f;
    float Dead_timer = 0f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("GroundTop") && this.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (animator.GetBool("Player_jumpdown") == true)
            {
                animator.SetBool("Player_jumpdown", false);
            }
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("GroundBottom"))
        {
            if (animator.GetBool("Player_jumpdown") == true)
            {
                animator.SetBool("Player_jumpdown", false);
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("GroundCheck") && this.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Player");
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("GroundTop"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Player");
            ObjectName = "GroundTop";
        }
        if (col.gameObject.layer == LayerMask.NameToLayer("GroundBottom"))
        {
            this.gameObject.layer = LayerMask.NameToLayer("Player");
            ObjectName = "GroundBottom";
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (ObjectName == "GroundBottom" || ObjectName == "GroundTop")
        {
            ObjectName = "OutGround";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        MaxHp = 50;
        nowHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (nowHp <= 0)
        {
            Dead();
        }
        if (PlayerHit)
        {
            Hit();
        }
        if(Dead_MoveLock == false)
        {
            switch(ObjectName)
            {
                case "GroundBottom":
                case "GroundTop":
                    if (JumpStart == true)
                    {
                        JumpStart = false;
                    }
                    else
                    {
                        rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
                    }
                    break;
                default:
                    rigid2D.velocity = new Vector2(rigid2D.velocity.x, rigid2D.velocity.y);
                    break;
            }
            if(rigid2D.velocity.y > 0)
            {
                animator.SetBool("Player_idle", false);
                animator.SetBool("Player_run", false);
                animator.SetBool("Player_jump", true);
                animator.SetBool("Player_jumpdown", false);
            }
            if(rigid2D.velocity.y < 0)
            {
                if(rigid2D.velocity.y < -7)
                {
                    rigid2D.velocity = new Vector2(rigid2D.velocity.x, -7);
                }
                animator.SetBool("Player_jump", false);
                animator.SetBool("Player_jumpdown", true);
                if(this.gameObject.layer == LayerMask.NameToLayer("PlayerJump") && ObjectName == "OutGround")
                {
                    this.gameObject.layer = LayerMask.NameToLayer("PlayerCheck");
                }
            }
            if(rigid2D.velocity.y == 0 && ObjectName == "GroundBottom")
            {
                animator.SetBool("Player_jump", false);
                animator.SetBool("Player_jumpdown", false);
            }
            if (rigid2D.velocity.y == 0 && ObjectName == "GroundTop")
            {
                animator.SetBool("Player_jump", false);
                animator.SetBool("Player_jumpdown", false);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && !LeftStart)
            {
                Left = true;
                RightStart = true;
                transform.localScale = new Vector3(-1, 1, 0);
                if (JumpStart == false)
                {
                    animator.SetBool("Player_run", true);
                    animator.SetBool("Player_idle", false);
                }
            }
            else
            {
                Left = false;
                RightStart = false;
            }

            if (Input.GetKey(KeyCode.RightArrow) && !RightStart)
            {
                Right = true;
                LeftStart = true;
                transform.localScale = new Vector3(1, 1, 0);
                if (JumpStart == false)
                {
                    animator.SetBool("Player_run", true);
                    animator.SetBool("Player_idle", false);
                }
            }
            else
            {
                Right = false;
                LeftStart = false;
            }

            if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
            {
                if(JumpStart == false)
                {
                    animator.SetBool("Player_idle", true);
                    animator.SetBool("Player_jumpdown", false);
                }
                animator.SetBool("Player_run", false);
                rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.Space) && JumpStart == false)
            {
                if(!door.EndingDoor == true)
                {
                    Jump = true;
                    this.gameObject.layer = LayerMask.NameToLayer("PlayerJump");
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (Left == true)
        {
            rigid2D.velocity = new Vector2(-5f, rigid2D.velocity.y);
            Right = false;
        }
        if (Right == true)
        {
            rigid2D.velocity = new Vector2(5f, rigid2D.velocity.y);
            Left = false;
        }

        if (Jump == true)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
            rigid2D.AddForce(Vector2.up * jumpPower * jumpPower);
            JumpStart = true;
            Jump = false;
        }
    }
    void Hit()
    {
        animator.SetBool("Player_hit", true);
        if(Hit_timer < 1f)
        {
            Hit_timer += Time.deltaTime;
            if(OneHit == true)
            {
                nowHp -= 10;
                Hpbar.fillAmount = (float)nowHp / (float)MaxHp;
                OneHit = false;
            }
        }
        else
        {
            animator.SetBool("Player_hit", false);
            OneHit = true;
            PlayerHit = false;
            Hit_timer = 0f;
        }
    }
    void Dead()
    {
        gameOver.SetActive(true);
        Dead_MoveLock = true;
        drop.dropFood = false;
        rigid2D.constraints = RigidbodyConstraints2D.FreezePosition;
        rigid2D.velocity = Vector2.zero;
        if(Dead_timer < 0.65f)
        {
            Dead_timer += Time.deltaTime;
            animator.SetBool("Player_dead", true);
        }
        else
        {
            animator.SetBool("Player_dead", false);
        }
    }
}
