using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

	public Transform player;
	private Animator anim;
	public int in_combat = 0;
	public bool is_corpse = false;
	private float speed = 1f;
	private CharacterController controller;
	private Vector3 direction;
	detectHit hit;
	private NavMeshAgent nav;
	private bool recent_damage;
	public AudioSource audio;
	public AudioClip msc;
	public AudioClip walking;
	public AudioClip hit_by_player;
	public AudioClip attack2;
	public AudioClip attack1;
	public float fiedlOfViewAngle =110f;
	private bool alerted =false;



	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource>();
		recent_damage = false;
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void Update () 
	{

		if(is_corpse){
			     foreach(Collider c in GetComponents<Collider> ()) {
				c.enabled = false;
			}
		}
		else{
		in_combat--;
		hit = gameObject.GetComponentInChildren<detectHit>();
		if(hit.parry == true){
			audio.PlayOneShot(msc,0.7f);
			in_combat = 50;
			hit.parry = false;


		}


		 CharacterController controller = GetComponent<CharacterController>();

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 25 && angle < 180){
			RaycastHit detect;
			if(Physics.Raycast(transform.position + transform.up,direction.normalized,out detect)){

				if(detect.collider.tag =="Hitbox"){
										alerted =true;
				}
			   }
			

		}
		if(alerted)
				{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);
			
			/*
			Vector3 movement = direction*speed;
			*/
		
				anim.SetBool("is_idle",false);
				if(direction.magnitude > 2 && in_combat <0)
				{
					/* I did not like how walking sounded from multiple enemeies
					if(audio.isPlaying == false){
						audio.PlayOneShot(walking,0.7f);
					}
					*/
					anim.ResetTrigger("is_blocked");
					recent_damage = false;
					nav.enabled = true;
					nav.SetDestination(player.position);

					/*
					 movement.y -= 20.0f * Time.deltaTime;
	
					controller.Move(movement * Time.deltaTime);
					*/

					anim.SetBool("is_walking",true);
					anim.SetBool("is_attacking",false);
					anim.SetBool("is_damaged",false);
					anim.SetBool("is_block1",false);
					anim.SetBool("is_attack2",false);
											
				}
				else if(in_combat<0)
				{
					recent_damage = false;
					int rando = Random.Range(1,4);
					if(rando==1){
					
					//delay for animation before skeleton can walk
						
							in_combat = 100;
						nav.enabled = false;
							anim.ResetTrigger("is_blocked");
							anim.SetBool("is_attacking",true);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);
							anim.SetBool("is_attack2",false);
					}
					else if(rando ==2){
						//delay for animation before skeleton can walk
						
							in_combat = 100;
							nav.enabled = false;
							anim.ResetTrigger("is_blocked");
							anim.SetBool("is_attacking",false);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",true);
							anim.SetBool("is_attack2",false);
						
					}
					else{
						//delay for animation before skeleton can walk
							in_combat = 100;
							nav.enabled = false;
							anim.ResetTrigger("is_blocked");
							anim.SetBool("is_attacking",false);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);
							anim.SetBool("is_attack2",true);
						

						
					}
	
				}
	
			}
			else 
			{
								recent_damage = false;
						nav.enabled = false;
				anim.SetBool("is_idle", true);
				anim.SetBool("is_walking", false);
				anim.SetBool("is_attacking", false);
				anim.SetBool("is_damaged",false);
				anim.SetBool("is_block1",false);
				anim.SetBool("is_attack2",false);
				
			}
		}

	}
	void OnTriggerEnter(Collider other){


		if(other.name=="HumanSword" && sword.can_damage>0&&!recent_damage){
			recent_damage = true;
			Debug.Log("hit by human");
			anim.Play("Damage",0, 0.0f);
			in_combat = 50;
			audio.PlayOneShot(hit_by_player,0.7f);
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
			GetComponent<EnemyHealthManager>().HurtEnemy(other.GetComponent<sword>().damageToGive);
			
		}
	}
	void PlayAttack2(){
					audio.PlayOneShot(attack2,0.7f);
		
	}
	void PlayAttack1(){
					audio.PlayOneShot(attack1,0.7f);
		
	}
	void SetInCombat(int x){
		in_combat = x;
		
	}

		
		
	
}
