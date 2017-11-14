using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectHit : MonoBehaviour {
	private Animator anim;
	public Transform player;
	public bool parry;
	
	void OnTriggerEnter(Collider other){


		if(other.name=="Cube"){
			Debug.Log("PARRY/BLOCK");
			GetBack();
			anim.SetTrigger("is_blocked");
		

			
		
		
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
		direction = direction*-1.0f;
				Debug.Log("2: "+direction);
		controller.Move(direction * 10*Time.deltaTime);
					Debug.Log("they should have moved");			

	
		
	}
}
