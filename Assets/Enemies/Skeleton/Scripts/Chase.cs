using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	public Transform player;
<<<<<<< HEAD
	public Animator anim;
=======
	private Animator anim;
	private int in_combat;
	private float speed = .3f;
	detectHit hit;
	


>>>>>>> bc1e3574ae3edce7113a804ac0501dc044b1728a

	// Use this for initialization
	void Start () 
	{

		anim = GetComponent<Animator>();
		in_combat = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		hit = gameObject.GetComponentInChildren<detectHit>();
		if(hit.parry == true){
			in_combat = 50;
			hit.parry = false;
		}
		in_combat--;

		 CharacterController controller = GetComponent<CharacterController>();

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
<<<<<<< HEAD
		if(Vector3.Distance(player.position, this.transform.position) < 15 && angle < 60)
=======
		if(Vector3.Distance(player.position, this.transform.position) < 25 && angle < 180)
>>>>>>> bc1e3574ae3edce7113a804ac0501dc044b1728a
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);
			
			
			Vector3 movement = direction*speed;

<<<<<<< HEAD
			anim.SetBool("is_idle",false);
			if(direction.magnitude > 2)
			{
				this.transform.Translate(0,0,0.05f);
				anim.SetBool("is_walking",true);
				anim.SetBool("is_attacking",false);
=======
		
				anim.SetBool("is_idle",false);
				if(direction.magnitude > 2 && in_combat <0)
				{

					 movement.y -= 20.0f * Time.deltaTime;
	
					controller.Move(movement * Time.deltaTime);
					anim.SetBool("is_walking",true);
					anim.SetBool("is_attacking",false);
					anim.SetBool("is_damaged",false);
					anim.SetBool("is_block1",false);
					anim.SetBool("is_attack2",false);
											
				}
				else
				{
					
					int rando = Random.Range(1,4);
					if(rando==1){
					
					//delay for animation before skeleton can walk
							if(in_combat<0){
							in_combat = 200;
							}
												anim.SetBool("is_attacking",true);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);
							anim.SetBool("is_attack2",false);
					}
					else if(rando ==2){
						//delay for animation before skeleton can walk
							if(in_combat<0){
							in_combat = 200;
							}

							anim.SetBool("is_attacking",false);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",true);
							anim.SetBool("is_attack2",false);
						
					}
					else{
						//delay for animation before skeleton can walk
							if(in_combat<0){
							in_combat = 150;
							}
						
							anim.SetBool("is_attacking",false);
							anim.SetBool("is_walking",false);
							anim.SetBool("is_damaged",false);
							anim.SetBool("is_block1",false);
							anim.SetBool("is_attack2",true);
						
					}
	
				}
	
>>>>>>> bc1e3574ae3edce7113a804ac0501dc044b1728a
			}
			else 
			{
				anim.SetBool("is_idle", true);
				anim.SetBool("is_walking", false);
				anim.SetBool("is_attacking", false);
				anim.SetBool("is_damaged",false);
				anim.SetBool("is_block1",false);
				anim.SetBool("is_attack2",false);
				
			}
		

	}
	void OnTriggerEnter(Collider other){


		if(other.name=="HumanSword" && sword.can_damage>0){
			anim.Play("Damage",0, 0.0f);
			in_combat = 50;
			anim.SetBool("is_idle", false);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
			anim.SetBool("is_block1",false);
			anim.SetBool("is_attack2",false);
			CharacterController controller = transform.root.GetComponent<CharacterController>();
			Vector3 direction = player.position - transform.position;
			direction.y=0;
			direction = direction*-3.0f;
			controller.Move(direction * 10*Time.deltaTime);
		
			

			
		}
		
	}

		
		
	
}
