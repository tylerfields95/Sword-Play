using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectHit : MonoBehaviour {
	private Animator anim;
	public Transform player;
	void OnTriggerEnter(Collider other){


		if(other.name=="Cube"){
			Debug.Log("PARRY/BLOCK");
			GetBack();
			anim.Play("Attack1Parry",0, 0.0f);
			anim.SetBool("is_idle", false);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
			anim.SetBool("is_block1",false);
			anim.SetBool("is_attack2",false);

			
		
		
		}
		
	}
	// Use this for initialization
	void Start () {
		anim = transform.root.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void  GetBack(){
		CharacterController controller = transform.root.GetComponent<CharacterController>();
		Vector3 direction = player.position - transform.root.transform.position;
		Debug.Log(direction);
		direction.y=0;
		direction = direction*-2.0f;
				Debug.Log("2: "+direction);
		controller.Move(direction * 10*Time.deltaTime);
					Debug.Log("they should have moved");			

	
		
	}
}
