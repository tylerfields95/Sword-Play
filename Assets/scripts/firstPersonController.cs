using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Services;
using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class firstPersonController : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;
	private bool New;
	private bool [] region = new bool[9];
	private float startT;
	private float endT;

	public GameObject sword;
	
    float verticleRotation = 0;
    public float upDownRange = 60.0f;

	private float verticalVelocity = 0;
	private Vector3 mousePos;

	private CharacterController characterController;
		
	// Use this for initialization
	void Start () {
        //locks cursor to the game
		characterController = GetComponent<CharacterController>();
		New = true;

	}
	
	// Update is called once per frame
	void Update () {
		
		
		
		//movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
		//Debug.Log("forward speed: " + forwardSpeed.ToString("F4"));
		//Debug.Log("side speed: " + sideSpeed.ToString("F4"));

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

		//grabs mouse position relative to the camera viewport (x=0.0-1.0, y=0.0-1.0) 
		//bottom left == (0.0f,0.0f)
		mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		ScreenRegion(mousePos);	
		
		

		
		/*
			//rotation
			float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
			transform.Rotate(0, rotLeftRight, 0);

			verticleRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
			verticleRotation = Mathf.Clamp(verticleRotation, -upDownRange, upDownRange);
			Camera.main.transform.localRotation = Quaternion.Euler(verticleRotation, 0, 0);
		*/
		
		
		
		if ( characterController.isGrounded && Input.GetButtonDown("Jump"))
		{
			verticalVelocity = jumpSpeed;
		}
		
		if (Input.GetButton("Sprint"))
		{
			forwardSpeed *= 1.5f;
			sideSpeed *= 1.5f;
		}
		
        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;

		characterController.Move(speed * Time.deltaTime);
	}

	void ScreenRegion(Vector3 mP)
	{	/*
		Debug.Log("entered ScreenRegion");
		
		setFalse();
		
		if ((mP.x > 0.33 && mP.x < 0.67) && (mP.y > 0.33 && mP.y < 0.67)) //Middle Middle
		{
			region[4] = true;
			startT = Time.time;
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("***********************************************");
		}
		if (mP.x < 0.34 && mP.y < 0.34) //Bottom Left
		{

			if (region[4] == true)
			{
				region[0] = true;
			}
			
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 0 " + region[0].ToString());
			Debug.Log("***********************************************");
			
		}
		if ((mP.x > 0.33 && mP.x < 0.67) && mP.y < 0.34) //Bottom Middle
		{
			if (region[4] == true)
			{
				region[1] = true;
			}
			
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 1 " + region[1].ToString());
			Debug.Log("***********************************************");
			
		}
		if (mP.x > 0.66 && mP.y < 0.34) //Bottom Right
		{
			if (region[4] == true)
			{
				region[2] = true;
			}
			
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 2 " + region[2].ToString());
			Debug.Log("***********************************************");
			
		}
		if (mP.x < 0.34 && (mP.y > 0.33 && mP.y < 0.67)) //Middle Left
		{
			{
			if (region[4] == true)
				region[3] = true;
			}
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 3 " + region[3].ToString());
			Debug.Log("***********************************************");
		}
		
		if (mP.x > 0.66 && (mP.y > 0.33 && mP.y < 0.67)) //Middle Right
		{
			if (region[4] == true)
			{
				region[5] = true;
			}
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 5 " + region[5].ToString());
			Debug.Log("***********************************************");
		}
		if (mP.x < 0.34 && mP.y > 0.66) //Top Left
		{
			if (region[4] == true)
			{
				region[6] = true;
			}
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 6 " + region[6].ToString());
			Debug.Log("***********************************************");
		}
		if ((mP.x > 0.33 && mP.x < 0.67) && mP.y > 0.66) //Top Middle
		{
			if (region[4] == true)
			{
				region[7] = true;
			}
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 7 " + region[7].ToString());
			Debug.Log("***********************************************");
		}
		if (mP.x > 0.66 && mP.y > 0.66) //Top Right
		{
			if (region[4] == true)
			{
				region[8] = true;
			}
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 8 " + region[8].ToString());
			Debug.Log("***********************************************");
		}

		if (region[3] == true && region[5] == true)
		{
			Debug.Log("swipe right to left");
			New = true;
			setFalse();
		}
		*/
	}

	void setFalse()
	{
		if (New == true)
		{
			for (var i = 0; i < 8; i++)
			{
				region[i] = false;
			}
			New = false;
		}
	}
}
