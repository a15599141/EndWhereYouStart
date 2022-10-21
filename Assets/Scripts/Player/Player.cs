using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class Player : PlayerController, IGetHealthSystem
{
    private HealthSystem healthSystem;
    private float healthAmountMax = 100f;
    [SerializeField] private ParticleSystem damageParticleSystem;

    // HealthSystem 
    private void Awake() {
            healthSystem = new HealthSystem(healthAmountMax);
            healthSystem.OnDead += HealthSystem_OnDead;
    }

    private void HealthSystem_OnDead(object sender, System.EventArgs e) {
            Animator anim = this.transform.Find("model").GetComponent<Animator>(); 
            anim.SetInteger("health",0);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Dead")){
                Destroy(gameObject);
            }
    }

    public void Damage(float damageAmount) {
            healthSystem.Damage(damageAmount);
            damageParticleSystem.Play();
    }

    public HealthSystem GetHealthSystem() {
            return healthSystem;
    }

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
                transform.transform.Translate(Vector2.right* move_x * MoveSpeed * Time.deltaTime);
            }
            else
            {
                transform.transform.Translate(new Vector3(move_x * MoveSpeed * Time.deltaTime, 0, 0));
            }

            if (!Input.GetKey(KeyCode.A))
                Filp(false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded)  
            {
                transform.transform.Translate(Vector2.right * move_x * MoveSpeed * Time.deltaTime);

            }
            else
            {
                transform.transform.Translate(new Vector3(move_x * MoveSpeed * Time.deltaTime, 0, 0));

            }

            if (!Input.GetKey(KeyCode.D))
                Filp(true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

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
