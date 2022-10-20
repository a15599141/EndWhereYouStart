using UnityEngine;

namespace CodeMonkey.HealthSystemCM {

    public class Weapon : MonoBehaviour {
        public GameObject model;

        private void OnTriggerEnter2D(Collider2D collider2D) {
            if (collider2D.TryGetComponent(out Enemy zombie) && model.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
                    zombie.Damage(20);
            }
        }

    }

}