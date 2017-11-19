using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int damageToGive;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
        }

        //if (health <= 0)
       // {

           // destroyEnemy();

        //}
    }

    //public void destroyEnemy()
    //{

        //other.gameObject.getComponent<EnemyHealthManager>().hurtEnemy;  //destroy our enemy
   // }
}
