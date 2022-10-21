using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class Enemy : MonoBehaviour, IGetHealthSystem {

        private HealthSystem healthSystem;
        private float healthAmountMax = 100f;
        [SerializeField] private ParticleSystem damageParticleSystem;

        public float speed = 1f;

        private void Awake() {
            healthSystem = new HealthSystem(healthAmountMax);
            healthSystem.OnDead += HealthSystem_OnDead;
        }

        private void Update() {
            Vector3 moveDir = new Vector3(-1, 0, 0);
            transform.position += moveDir * speed * Time.deltaTime;
        }

        private void HealthSystem_OnDead(object sender, System.EventArgs e) {
            Animator enemy_anim = this.transform.Find("model").GetComponent<Animator>(); 
            enemy_anim.Play("Dead");
            if(enemy_anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && enemy_anim.GetCurrentAnimatorStateInfo(0).IsName("Dead")){
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
}