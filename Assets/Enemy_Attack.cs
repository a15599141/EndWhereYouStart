using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.HealthSystemCM {

    /// <summary>
    /// Deal Damage to Player 
    /// </summary>
    public class Enemy_Attack: MonoBehaviour 
    {
        private Animator enemy_animator;
        
        private void Start() 
        {
            enemy_animator = this.transform.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if(enemy_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && enemy_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1){

            }else{
                if(collider2D.TryGetComponent(out Player player)){
                 enemy_animator.Play("Attack");
                 player.Damage(10f);
                }
            }
        }
    }

}
