﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class BossChase : MonoBehaviour {

	public Transform player;
	private Animator anim;
	public int in_combat = 0;
	public bool is_corpse = false;
	private float speed = 1f;
	private bool running = true;
	private bool can_turn = true;
	private CharacterController controller;
	private Vector3 direction;
	detectHit hit;
	private NavMeshAgent nav;
	



	// Use this for initialization
	void Start () 
	{
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{
	
		//Debug.Log(in_combat);
		

		if(is_corpse){
			     foreach(Collider c in GetComponents<Collider> ()) {
				c.enabled = false;
		}
		}
		else{
		in_combat--;
		hit = gameObject.GetComponentInChildren<detectHit>();
		if(hit.parry == true){
			controller = transform.root.GetComponent<CharacterController>();
			direction = player.position - transform.position;
			direction.y=0;
			if(anim.GetBool("is_charging")){
				Debug.Log("OH NO");
				anim.ResetTrigger("is_blocked");
				anim.Play("Knockback",0, 0.0f);
				anim.SetBool("is_idle", false);
				anim.SetBool("is_walking", false);
				anim.SetBool("is_attacking", false);
				anim.SetBool("is_damaged",false);
				anim.SetBool("is_block1",false);
				anim.SetBool("is_attack2",false);
				anim.SetBool("is_charging",false);
				in_combat = 200;
				running= false;	
				direction = direction*-3.0f;
				controller.Move(direction * 5*Time.deltaTime);
			   }
			else if(in_combat<50){	
			in_combat = 50;
			}
			hit.parry = false;
			nav.enabled = false;
		}


		  controller = GetComponent<CharacterController>();

		direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 25 && angle < 180)
		{

			
			direction.y = 0;
			
			if(can_turn){
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);
			}
		/*
			
			Vector3 movement = direction*speed;
		*/
		
				anim.SetBool("is_idle",false);
				if(direction.magnitude > 2 && in_combat <0)
				{
					anim.ResetTrigger("is_blocked");
					nav.SetDestination(player.position);
					nav.enabled = true;
										 can_turn = true;
					/*
					 movement.y -= 20.0f * Time.deltaTime;

					 
					controller.Move(movement * Time.deltaTime);
					*/
					anim.SetBool("is_walking",true);
					anim.SetBool("is_attacking",false);
					anim.SetBool("is_damaged",false);
					anim.SetBool("is_block1",false);
					anim.SetBool("is_attack2",false);
					anim.SetBool("is_charging",false);
					running = true;
											
				}
				else
				{
					int rando = Random.Range(1,5);
					if(running && rando >1 && in_combat<-125){
						anim.Play("Charge",0, 0.0f);
						anim.ResetTrigger("is_blocked");
						Debug.Log("Charge");
						in_combat = 100;
						nav.enabled = false;
						running = false;
						can_turn = false;
						anim.SetBool("is_charging",true);
							anim.SetBool("is_attacking",true);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);
							anim.SetBool("is_attack2",false);
													
					}
					else if(in_combat<0){
					
					running = false;
					rando = Random.Range(1,3);
					Debug.Log(rando);
					if(rando==1){
						
			
					//delay for animation before skeleton can walk
					
							can_turn = true;
							in_combat = 166;
							Debug.Log("attack");
							anim.ResetTrigger("is_blocked");
							anim.SetBool("is_attack2",false);
								anim.SetBool("is_attacking",true);
							anim.SetBool("is_charging",false);

							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);

						
							
						nav.enabled = false;
							

					}
					else{
						//delay for animation before skeleton can walk
							
							in_combat = 100;
							can_turn = true;
							Debug.Log("attack2");
							anim.ResetTrigger("is_blocked");
							anim.SetBool("is_attacking",false);
							anim.SetBool("is_attack2",true);
							anim.SetBool("is_charging",false);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);
							
						   nav.enabled = false;
						

						
					}
	
				}
	
			}
		}
		else if(in_combat <0)
			{	nav.enabled = false;
				anim.SetBool("is_idle", true);
				anim.SetBool("is_walking", false);
				anim.SetBool("is_attacking", false);
				anim.SetBool("is_damaged",false);
				anim.SetBool("is_block1",false);
				anim.SetBool("is_attack2",false);
				anim.SetBool("is_charging",false);
				
			}
		
			
			
			
		}

	}
	void OnTriggerEnter(Collider other){


		if(other.name=="HumanSword" && sword.can_damage>0){
			Debug.Log("hit by human");
			anim.Play("Damage",0, 0.0f);
			in_combat = 50;
			anim.SetBool("is_idle", false);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
			anim.SetBool("is_block1",false);
			anim.SetBool("is_attack2",false);
			controller = transform.root.GetComponent<CharacterController>();
			direction = player.position - transform.position;
			direction.y=0;
			direction = direction*-3.0f;
			controller.Move(direction * 10*Time.deltaTime);
		
			

			
		}
		
	}

		
		
	
}
