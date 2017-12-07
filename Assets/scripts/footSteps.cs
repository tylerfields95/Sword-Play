using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour
{
	private CharacterController firstPersonController;
	public AudioSource footStep;
	// Use this for initialization
	void Start ()
	{
		firstPersonController = GetComponent<CharacterController>();
		footStep.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (firstPersonController.isGrounded == true && firstPersonController.velocity.magnitude > 7 && footStep.isPlaying == false)
		{
			footStep.Play();
			footStep.pitch = 1.5f;
		}
		if (firstPersonController.isGrounded == true && firstPersonController.velocity.magnitude > 1 && footStep.isPlaying == false)
		{
			footStep.Play();
			footStep.pitch = 1;
		}
		

	}
}
