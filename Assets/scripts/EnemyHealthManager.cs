using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {
	private Animator anim;

    public int MaxHealth;
    public int CurrentHealth;
    public string death_animation;
    [SerializeField] private Transform enemy;
   /* [SerializeField] private Transform enemyRespawnPoint;*/
	// Use this for initialization
	void Start () {
		anim = enemy.GetComponent<Animator>();
        CurrentHealth = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentHealth <= 0)
       //makes sure the user cant reset the death animation
        {	CurrentHealth =1000;
        	anim.Play(death_animation);
    		enemy.root.GetComponent<Chase>().is_corpse = true;
        	/*enemy.transform.position = enemyRespawnPoint.transform.position;
        	CurrentHealth = 30;*/
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
