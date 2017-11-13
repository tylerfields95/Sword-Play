using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Remoting.Services;
using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class firstPersonController : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float movementSpeedNorm = 5.0f;
    public float walkSpeed = 2.0f;
    public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;

	
	
    float verticleRotation = 0;
    public float upDownRange = 60.0f;

	private float verticalVelocity = 0;
	private Vector3 mousePos;

	private CharacterController characterController;
		
	// Use this for initialization
	void Start () {
        //locks cursor to the game
        characterController = GetComponent<CharacterController>();


	}
	
	// Update is called once per frame
	void Update () {
		
		//movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		
		//gravity
		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		//as long as the left mouse button isnt being held you can look around
		if (!Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.Locked;
			//rotation
			float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotLeftRight, 0);

			verticleRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
			verticleRotation = Mathf.Clamp(verticleRotation, -upDownRange, upDownRange);
			Camera.main.transform.localRotation = Quaternion.Euler(verticleRotation, 0, 0);
		}
		
		
		
		//jumping
		if ( characterController.isGrounded && Input.GetButtonDown("Jump"))
		{
			verticalVelocity = jumpSpeed;
		}
		
		//sprinting speed
		if (Input.GetButton("Sprint"))
		{
			forwardSpeed *= 1.5f;
			sideSpeed *= 1.5f;
		}
		
		//actually moving the character controller 
        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
		characterController.Move(speed * Time.deltaTime);
	}
}
