using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    [SerializeField] Sound_Script sound;
    [SerializeField] FoodDrop_Script drop;
    [SerializeField] Ending_Script door;

    [SerializeField] Rigidbody2D rigid2D;
    [SerializeField] CapsuleCollider2D topBox2D;
    [SerializeField] BoxCollider2D bottomBox2D;
    [SerializeField] Animator animator;
    [SerializeField] Image Hpbar;
    [SerializeField] GameObject gameOver;
    [SerializeField] string ObjectName;

    RaycastHit2D hit1;

    public LayerMask hitLayer;
    
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

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            if (col.bounds.center.x != transform.position.x)
            {
                Vector2 bounceDirection = new Vector2(col.transform.position.x - transform.position.x, 0).normalized;
                transform.position += (Vector3)(bounceDirection * Time.deltaTime * 5f);
            }
        }
        if(col.gameObject.layer == LayerMask.NameToLayer("WallTop"))
        {
            if (col.bounds.center.y != transform.position.y)
            {
                Vector2 bounceDirection = new Vector2(0, col.transform.position.y - transform.position.y).normalized;
                transform.position += (Vector3)(bounceDirection * Time.deltaTime * 5f);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        MaxHp = 250;
        nowHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
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
            if (this.gameObject.layer == LayerMask.NameToLayer("Player") ||
                this.gameObject.layer == LayerMask.NameToLayer("PlayerCheck"))
            {
                hit1 = Physics2D.BoxCast(new Vector2(transform.position.x + 0.1f, transform.position.y - 0.75f), new Vector2(0.2f, 0.15f),
                    0, Vector2.down, 0.15f, hitLayer);

                Debug.DrawRay(transform.position + new Vector3(-new Vector2(0.2f, 0.15f).x / 2, -0.75f), Vector2.down * 0.15f);
                Debug.DrawRay(transform.position + new Vector3(new Vector2(0.2f, 0.15f).x / 2, -0.75f), Vector2.down * 0.15f);
            }
            else hit1 = new RaycastHit2D();

            if (hit1.collider != null)
            {
                //Debug.Log(hit1.collider.gameObject.name);

                if (hit1.collider.gameObject.name == "GroundUp")
                {
                    //bottomBox2D.enabled = true;
                    topBox2D.isTrigger = false;
                    if (JumpStart && rigid2D.velocity.y > 0)
                    {
                        animator.SetBool("Player_idle", false);
                        animator.SetBool("Player_run", false);
                        animator.SetBool("Player_jump", true);
                        animator.SetBool("Player_jumpdown", false);
                    }
                    if (rigid2D.velocity.y < 0)
                    {
                        if (rigid2D.velocity.y < -7)
                        {
                            rigid2D.velocity = new Vector2(rigid2D.velocity.x, -7);
                        }
                        animator.SetBool("Player_jump", false);
                        animator.SetBool("Player_jumpdown", true);
                        if (this.gameObject.layer == LayerMask.NameToLayer("PlayerJump") && ObjectName == "OutGround")
                        {
                            this.gameObject.layer = LayerMask.NameToLayer("PlayerCheck");
                        }
                    }

                    if(rigid2D.velocity.y == 0) rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0);
                    this.gameObject.layer = LayerMask.NameToLayer("Player");
                    if (animator.GetBool("Player_jumpdown"))
                    {
                        animator.SetBool("Player_jumpdown", false);
                        if (JumpStart) JumpStart = false;
                    }
                }
                if (hit1.collider.gameObject.name == "BottomGround")
                {
                    topBox2D.isTrigger = false;
                    this.gameObject.layer = LayerMask.NameToLayer("Player");
                    if (animator.GetBool("Player_jumpdown"))
                    {
                        animator.SetBool("Player_jumpdown", false);
                        animator.SetBool("Player_idle", true);
                        if (JumpStart) JumpStart = false;
                    }
                }
            }
            else
            {
                topBox2D.isTrigger = true;
                if (JumpStart && rigid2D.velocity.y > 0)
                {
                    animator.SetBool("Player_idle", false);
                    animator.SetBool("Player_run", false);
                    animator.SetBool("Player_jump", true);
                    animator.SetBool("Player_jumpdown", false);
                }
                if (rigid2D.velocity.y < 0)
                {
                    if (rigid2D.velocity.y < -7)
                    {
                        rigid2D.velocity = new Vector2(rigid2D.velocity.x, -7);
                    }
                    animator.SetBool("Player_jump", false);
                    animator.SetBool("Player_jumpdown", true);
                    if (this.gameObject.layer == LayerMask.NameToLayer("PlayerJump") && ObjectName == "OutGround")
                    {
                        this.gameObject.layer = LayerMask.NameToLayer("PlayerCheck");
                    }
                }
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
                if (JumpStart == false)
                {
                    animator.SetBool("Player_idle", true);
                    animator.SetBool("Player_jumpdown", false);
                }
                animator.SetBool("Player_run", false);
                rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
            }

            if (Input.GetKeyDown(KeyCode.Space) && JumpStart == false)
            {
                hit1 = new RaycastHit2D();
                if (!door.EndingDoor == true)
                {
                    Jump = true;
                    this.gameObject.layer = LayerMask.NameToLayer("PlayerJump");
                }
            }
        }
        else
        {
            if (JumpStart) JumpStart = false;
            topBox2D.isTrigger = false;
            rigid2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            transform.position = new Vector2(transform.position.x, transform.position.y);
            this.gameObject.layer = LayerMask.NameToLayer("Player");
            animator.SetBool("Player_idle", true);
            animator.SetBool("Player_run", false);
            animator.SetBool("Player_jump", false);
            animator.SetBool("Player_jumpdown", false);
            animator.SetBool("Player_hit", false);
        }
    }
    void FixedUpdate()
    {
        if (Left == true)
        {
            rigid2D.velocity = new Vector2(-5, rigid2D.velocity.y);
            Right = false;
        }
        if (Right == true)
        {
            rigid2D.velocity = new Vector2(5, rigid2D.velocity.y);
            Left = false;
        }

        if (Jump == true)
        {
            sound.PlaySound(sound.audioClip[0]);
            rigid2D.AddForce(Vector2.up * jumpPower * jumpPower, ForceMode2D.Impulse);
            if (rigid2D.velocity.y > 8) rigid2D.velocity = new Vector2(rigid2D.velocity.x, 8);
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
