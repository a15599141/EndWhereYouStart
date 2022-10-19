using UnityEngine;

namespace CodeMonkey.HealthSystemCM {

    public class BulletDamage : MonoBehaviour {


        private void Start() {
            float bulletSpeed = 200f;
            GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
        }

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if (collider2D.TryGetComponent(out Enemy zombie)) {
                zombie.Damage();
                Destroy(gameObject);
            }
        }

    }

}