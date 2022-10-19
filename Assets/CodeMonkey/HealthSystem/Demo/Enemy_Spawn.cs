using UnityEngine;

namespace CodeMonkey.HealthSystemCM {

    public class Enemy_Spawn : MonoBehaviour {

        [SerializeField] private Transform ZombiePrefab;

        private float spawnTimer;
        private float spawnTimerMax = 5f; //怪物刷新间隔

        private void Update() {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f) {
                spawnTimer += spawnTimerMax;
                Spawn();
            }
        }

        private void Spawn() {
            Vector3 spawnPosition = ZombiePrefab.position; //生成在预制体的位置
            Instantiate(ZombiePrefab, spawnPosition, Quaternion.identity);
        }

    }

}