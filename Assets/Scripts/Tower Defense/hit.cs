using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.HealthSystemCM;

public class hit : MonoBehaviour
{
    public Transform target;
    float speed = 3f;
    Vector3 lastspeed;
    Vector3 finalForward;
    RaycastHit hit02;

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            transform.Translate((enemy.transform.position - transform.position).normalized * speed * Time.fixedDeltaTime);
            if(Vector3.Distance(enemy.transform.position, transform.position) < 0.1f){

                Destroy(this.gameObject);
            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D) {
                if(collider2D.TryGetComponent(out Enemy zombie)){
                 zombie.Damage(20f);
                }
        }





    /*  private Rigidbody2D rigidbody;

      public GameObject Aim;
      public GameObject BulletPrefab;
      public float N = 50;

      bool isAttack = false;

      private Vector2 PlayerVect;
      private Vector2 AttackVect;

      float time = 0;

      void Awake()
      {
          rigidbody = this.GetComponent<Rigidbody2D>(); 
      }
      void Update()
      {
          PlayerVect.x = Aim.transform.position.x;
          PlayerVect.y = Aim.transform.position.y;
          AttackVect.x = PlayerVect.x - this.transform.position.x;
          AttackVect.y = PlayerVect.y - this.transform.position.y;

          if (!isAttack)
          {
              time = time + Time.deltaTime;
              if (time >= 1)
              {
                  Launch();
                  time = 0;
              }

          }
      }

      private void Start()
      {

      }

      public void Lauch(Vector2 direction, float force)
      {
          rigidbody.AddForce(direction * force);  

      }

      private void Launch()
      {
          GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
          bullet.GetComponent<hit>().Lauch(AttackVect, N);
          Vector3 offset = Aim.transform.position - BulletPrefab.transform.position;

      }*/

}
