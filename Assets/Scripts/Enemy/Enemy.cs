using UnityEngine;

namespace CodeMonkey.HealthSystemCM {

    public class Enemy : MonoBehaviour, IGetHealthSystem {

        private HealthSystem healthSystem;
        private float healthAmountMax = 100f;
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
            Destroy(gameObject);
        }

        public void Damage(int damage) {
            healthSystem.Damage(damage);
        }

        public HealthSystem GetHealthSystem() {
            return healthSystem;
        }
    }

}