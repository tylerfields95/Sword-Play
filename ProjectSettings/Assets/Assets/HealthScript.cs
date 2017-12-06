using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public float health = 100f; //How much health does the baddie have
    public float damageConstant = 1f; //What do we want to set our damage multiplier to.
 
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.relativeVelocity.magnitude > 10)
        { //remove this 

            health -= damageConstant * collision.relativeVelocity.magnitude; //line 1
                                                                             //Have our enemy turn red
        }  //remove this

        if (health < 0)
        {

            destroyEnemy();

        }

    }

    public void destroyEnemy()
    {

        Destroy(gameObject);  //destroy our enemy
    }
}
