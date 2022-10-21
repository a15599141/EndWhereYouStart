using UnityEngine;

namespace CodeMonkey.HealthSystemCM {

    public class Demo_DefenseGame : MonoBehaviour {

        [SerializeField] private Transform pfZombie;

        private float spawnTimer;
        private float spawnTimerMax = 5f;

        private void Update() {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f) {
                spawnTimer += spawnTimerMax;
                SpawnZombie();
            }
        }

        private void SpawnZombie() {
            Vector3 spawnPosition = new Vector3(Random.Range(+10, +20), -3.2f, 0);
            Instantiate(pfZombie, spawnPosition, Quaternion.identity);
        }

    }

}