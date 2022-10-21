using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paota : MonoBehaviour
{
    public GameObject missile;
    float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime>2)
        {
            currentTime = 0;
            GameObject m = GameObject.Instantiate(missile);
            m.transform.localPosition = transform .position ;
            m.SetActive(true);
        }
    }


    /* public GameObject Aim;
     public GameObject BulletPrefab;
     public float N = 50;

     bool isAttack = false; 

     private Vector2 PlayerVect;
     private Vector2 AttackVect;

     float time = 0;
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

     private void Launch()
     {
         GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);  
         bullet.GetComponent<hit>().Lauch(AttackVect, N);
         Vector3 offset = Aim.transform.position - BulletPrefab.transform.position;

     }

   *//*  private void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.tag == "Player")
         {
             isAttack = true;
         }
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.tag == "Player")
         {
             isAttack = false;
         }
     }*/

}
