using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class firstPersonController : MonoBehaviour {
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;

    float verticleRotation = 0;
    public float upDownRange = 60.0f;

	private float verticalVelocity = 0;

	private CharacterController characterController;
		

	// Use this for initialization
	void Start () {
        //locks cursor to the game
        Cursor.lockState = CursorLockMode.Locked;
		characterController = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

        //rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);

        verticleRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticleRotation = Mathf.Clamp(verticleRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticleRotation, 0, 0);

        //movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

		verticalVelocity += Physics.gravity.y * Time.deltaTime;

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
}
