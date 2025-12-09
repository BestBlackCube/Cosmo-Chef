using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid2D;
    [SerializeField] BoxCollider2D box2D;
    [SerializeField] Animator animator;
    [SerializeField] Image Hpbar;
    [SerializeField] GameObject gameOver;
    public bool Player_Move = false;

    bool Left = false;
    bool LeftStart = false;
    bool Right = false;
    bool RightStart = false;

    public bool PlayerHit = false;
    public bool OneHit = true;
    public bool MoveRock = false;

    public bool JumpStart = false;
    public bool Jump = false;
    bool AutoJump = false;

    public bool JumpPad = false;

    public int nowHp;
    public int MaxHp;

    public float movePower = 20f;
    public float jumpPower = 22f;
    public float Jump_timer = 0f;
    float Hit_timer = 0f;
    float Dead_timer = 0f;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (JumpStart == true)
            {
                JumpStart = false;
            }
            if(AutoJump == true)
            {
                AutoJump = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Spike"))
        {
            PlayerHit = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 100;
        nowHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (nowHp <= 0)
        {
            Dead();
        }
        if (PlayerHit)
        {
            Hit();
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
        if(Player_Move == true)
        {
            if(MoveRock == false)
            {
                if (JumpStart && rigid2D.velocity.y < 0)
                {
                    animator.SetBool("Player_jump", false);
                }
                if (Input.GetKey(KeyCode.LeftArrow) && !LeftStart)
                {
                    Left = true;
                    RightStart = true;
                    transform.localScale = new Vector3(-1, 1, 0);
                    if (!JumpStart)
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
                    rigid2D.velocity = new Vector2(0, rigid2D.velocity.y);
                    animator.SetBool("Player_run", false);
                    if (JumpStart == false)
                    {
                        animator.SetBool("Player_idle", true);
                    }
                }

                if (Input.GetKeyDown(KeyCode.Space) && JumpStart == false)
                {
                    Jump = true;
                    animator.SetBool("Player_jump", true);
                }
            }
        }
        else
        {
            if(AutoJump == true && rigid2D.velocity.y < 0f)
            {
                animator.SetBool("Player_jump", false);
            }
            if (rigid2D.velocity.x > 2f)
            {
                rigid2D.velocity = new Vector3(2f, rigid2D.velocity.y, 0);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 0);
                rigid2D.AddForce(Vector2.right * 2f);
                rigid2D.velocity = new Vector3(rigid2D.velocity.x, rigid2D.velocity.y, 0);
                if(AutoJump == false)
                {
                    animator.SetBool("Player_run", true);
                }
            }
        }
    }
    void FixedUpdate()
    {
        if (JumpPad == true)
        {
            rigid2D.AddForce(Vector2.up * jumpPower * jumpPower);
            AutoJump = true;
            animator.SetBool("Player_jump", true);
            animator.SetBool("Player_run", false);
            JumpPad = false;
        }
        if (Left == true)
        {
            if (rigid2D.velocity.x < -2f) rigid2D.velocity = new Vector3(-2f, rigid2D.velocity.y, 0);
            rigid2D.AddForce(Vector2.left * movePower);
            Right = false;
        }
        if (Right == true)
        {
            if (rigid2D.velocity.x > 2f) rigid2D.velocity = new Vector3(2f, rigid2D.velocity.y, 0);
            rigid2D.AddForce(Vector2.right * movePower);
            Left = false;
        }

        if (Jump == true)
        {
            rigid2D.AddForce(Vector2.up * jumpPower * jumpPower);
            JumpStart = true;
            animator.SetBool("Player_idle", false);
            animator.SetBool("Player_run", false);
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
        MoveRock = true;
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
