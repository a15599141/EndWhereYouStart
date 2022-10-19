using UnityEngine;
using UnityEngine.UI;

namespace CodeMonkey.HealthSystemCM {

    /// <summary>
    /// Deal Damage to the HealthSystem on Click
    /// </summary>
    public class HammerDamage: MonoBehaviour {

        [SerializeField] private GameObject getHealthSystemGameObject;
        public void Start() {
            //HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem, true);
            //healthSystem.Damage(10);
            //print("得到HP");

        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem, true);
                healthSystem.Damage(10);
                print("鼠标左键被按下！");
            }
            
        }
    }

}