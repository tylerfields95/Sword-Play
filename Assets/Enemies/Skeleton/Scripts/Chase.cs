using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {

	public Transform player;
	public Animator anim;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 direction = player.position - this.transform.position;
		float angle = Vector3.Angle(direction,this.transform.forward);
		if(Vector3.Distance(player.position, this.transform.position) < 15 && angle < 60)
		{
			
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
										Quaternion.LookRotation(direction), 0.1f);

			anim.SetBool("is_idle",false);
			if(direction.magnitude > 5)
			{
				this.transform.Translate(0,0,0.05f);
				anim.SetBool("is_walking",true);
				anim.SetBool("is_attacking",false);
			}
			else
			{
				anim.SetBool("is_attacking",true);
				anim.SetBool("is_walking",false);
			}

		}
		else 
		{
			anim.SetBool("is_idle", true);
			anim.SetBool("is_walking", false);
			anim.SetBool("is_attacking", false);
		}

	}
}
