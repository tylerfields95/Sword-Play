using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    public int MaxHealth;
    public int CurrentHealth;
<<<<<<< HEAD
=======
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform enemyRespawnPoint;
>>>>>>> bc1e3574ae3edce7113a804ac0501dc044b1728a
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentHealth <= 0)
        {
<<<<<<< HEAD
            Destroy (gameObject);
=======
        	enemy.transform.position = enemyRespawnPoint.transform.position;
        	CurrentHealth = 30;
>>>>>>> bc1e3574ae3edce7113a804ac0501dc044b1728a
        }
		
	}

    public void HurtEnemy (int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
