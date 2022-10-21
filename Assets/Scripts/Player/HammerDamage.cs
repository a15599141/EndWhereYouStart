using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.HealthSystemCM {

    /// <summary>
    /// Deal Damage to Enemy on Click
    /// </summary>
    public class HammerDamage: MonoBehaviour 
    {
        private Animator player_animator;
        
        private void Start() 
        {
            player_animator = this.transform.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if(player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && player_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1){

            }else{
                if(collider2D.TryGetComponent(out Enemy zombie)){
                 player_animator.Play("Attack");
                 zombie.Damage(20f);
                }
            }
             
        }

        private void OnTriggerStay2D(Collider2D collider2D) {
            if(player_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && player_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1){
                if(collider2D.TryGetComponent(out Enemy zombie)){
                 player_animator.Play("Attack");
                 zombie.Damage(10f);
                }
            }
             
        }

        private void DestroyPlayer(){
            Destroy(GameObject.FindWithTag("Player"));
        }
    }

}