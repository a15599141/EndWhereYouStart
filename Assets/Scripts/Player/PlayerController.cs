using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController :MonoBehaviour
{
    public bool IsSit = false;
    public int currentJumpCount = 0; 
    public bool isGrounded = false;
    public bool OnceJumpRayCheck = false;

    public bool Is_DownJump_GroundCheck = false;   
    protected float move_x; // 连续移动
    public Rigidbody2D m_rigidbody;
    protected CapsuleCollider2D m_CapsulleCollider;
    protected Animator player_animator;

    [Header("[Setting]")]
    public float MoveSpeed = 6;
    public int JumpCount = 2;  // 允许的跳跃次数
    public float jumpForce = 15f; 

    protected void AnimUpdate()
    {
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
    }

    protected void Filp(bool faceRight) //人物转向
    {
        transform.localScale = new Vector3(faceRight ? -1 : 1, 1, 1);
    }

    protected void prefromJump()
    {
        player_animator.Play("Jump");

        m_rigidbody.velocity = new Vector2(0, 0);

        m_rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        OnceJumpRayCheck = true;
        isGrounded = false;
        currentJumpCount++;

    }

    protected void DownJump()
    {
        if (!isGrounded)
            return;

        if (!Is_DownJump_GroundCheck) //快速下落
        {
            player_animator.Play("Jump");

            m_rigidbody.AddForce(-Vector2.up * 10);
            isGrounded = false;

            m_CapsulleCollider.enabled = false;

            StartCoroutine(GroundCapsulleColliderTimmerFuc());
        }
    }

    IEnumerator GroundCapsulleColliderTimmerFuc()
    {
        yield return new WaitForSeconds(0.3f);
        m_CapsulleCollider.enabled = true;
    }
    Vector2 RayDir = Vector2.down;

    float PretmpY;
    float GroundCheckUpdateTic = 0;
    float GroundCheckUpdateTime = 0.01f;
    protected void GroundCheckUpdate()
    {
        if (!OnceJumpRayCheck)
            return;
        GroundCheckUpdateTic += Time.deltaTime;

        if (GroundCheckUpdateTic > GroundCheckUpdateTime)
        {
            GroundCheckUpdateTic = 0;
            if (PretmpY == 0)
            {
                PretmpY = transform.position.y;
                return;
            }

            float reY = transform.position.y - PretmpY;  //    -1  - 0 = -1 ,  -2 -   -1 = -3

            if (reY <= 0)
            {

                if (isGrounded)
                {
                    LandingEvent();
                    OnceJumpRayCheck = false;
                }
            }
            PretmpY = transform.position.y;
        }
    }
    protected abstract void LandingEvent();


}
