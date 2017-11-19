using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
    public int MaxHealth;
    public int CurrentHealth;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform enemyRespawnPoint;
	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentHealth <= 0)
        {
        	enemy.transform.position = enemyRespawnPoint.transform.position;
        	CurrentHealth = 30;
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
