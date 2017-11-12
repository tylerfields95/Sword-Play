using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	public Transform player;
	private Animator anim;
	float speed = .5f;



	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		 CharacterController controller = GetComponent<CharacterController>();

		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 20 && angle < 90)
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);
			
			
			Vector3 movement = direction*speed;
		

			anim.SetBool("is_idle",false);
			if(direction.magnitude > 3)
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

					
				anim.SetBool("is_attacking",true);
						anim.SetBool("is_walking",false);
						anim.SetBool("is_damaged",false);
						anim.SetBool("is_block1",false);
						anim.SetBool("is_attack2",false);
				}
				else if(rando ==2){

						anim.SetBool("is_attacking",false);
						anim.SetBool("is_walking",false);
						anim.SetBool("is_damaged",false);
						anim.SetBool("is_block1",true);
						anim.SetBool("is_attack2",false);
					
				}
				else{
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
			anim.SetBool("is_idle", true);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
			anim.SetBool("is_damaged",false);
			anim.SetBool("is_block1",false);
			anim.SetBool("is_attack2",false);
			
		}

	}
	void OnTriggerEnter(Collider other){

		
		if(other.name=="Cube"){
			anim.Play("Damage",0, 0.0f);
			anim.SetBool("is_idle", false);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
			anim.SetBool("is_block1",false);
			anim.SetBool("is_attack2",false);

			
		}
		
	}

		
		
	
}
