using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerController
{
    private void Start()
    {
        // 获取动画、刚体和碰撞器组件
        m_CapsulleCollider  = this.transform.GetComponent<CapsuleCollider2D>();
        player_animator = this.transform.Find("model").GetComponent<Animator>();
        m_rigidbody = this.transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        checkInput();//玩家移动控制
        if (m_rigidbody.velocity.magnitude > 30)
        {
            //移速控制
            m_rigidbody.velocity = new Vector2(m_rigidbody.velocity.x - 0.1f, m_rigidbody.velocity.y - 0.1f);
        }
    }

    public void checkInput()
    {
        move_x = Input.GetAxis("Horizontal");
        GroundCheckUpdate();

        if (!player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                player_animator.Play("Attack");
            }
            else
            {
                if (move_x == 0)
                {
                    if (!OnceJumpRayCheck)
                        player_animator.Play("Idle");
                }
                else
                {
                    player_animator.Play("Run");
                }
            }
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (isGrounded)  
            {
                if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;
                transform.transform.Translate(Vector2.right* move_x * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(move_x * MoveSpeed * Time.deltaTime, 0, 0));
            }
            if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.A))
                Filp(false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded)  
            {
                if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                    return;
                transform.transform.Translate(Vector2.right * move_x * MoveSpeed * Time.deltaTime);

            }
            else
            {
                transform.transform.Translate(new Vector3(move_x * MoveSpeed * Time.deltaTime, 0, 0));

            }
            if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (!Input.GetKey(KeyCode.D))
                Filp(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
                return;

            if (currentJumpCount < JumpCount)  // 0 , 1
            {
                if (!IsSit)
                {
                    prefromJump();
                }
                else
                {
                    DownJump();
                }
            }
        }
    }
    protected override void LandingEvent()
    {
        if (!player_animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && !player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            player_animator.Play("Idle");
    }
}
