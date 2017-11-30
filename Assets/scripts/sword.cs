using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sword : MonoBehaviour {
	
	private bool [] region = new bool[9];
	private float startT;
	private float endT;
    public Slider staminaSlider;
    private Vector3 mousePos;
    public int damageToGive;
    public Animator swordAnimator;
    public static int can_damage;
	private Boolean canAttack = true;


	// Use this for initialization
	void Start () {
		swordAnimator = GetComponent<Animator>();
	}

	private Vector2 lastAxis;
	private Vector2 currAxis;
	
	// Update is called once per frame
	void Update () {
		can_damage --;
		
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.None;
			//Cursor.visible = false;
			
			float axisX = Input.GetAxis("Mouse X");
			float axisY = Input.GetAxis("Mouse Y");
			//Debug.Log("x: " + axisX.ToString());
			//Debug.Log("y:" + axisY.ToString());
			currAxis.x = Input.GetAxis("Mouse X");
			currAxis.y = Input.GetAxis("Mouse Y");
			

			Debug.Log("curr: " + currAxis.x.ToString());

			if (currAxis.x > 0.5 && canAttack == true) 
			{
				swordAnimator.SetTrigger("right_ready");
				Debug.Log("right_ready");
			}
		}

		if (Input.GetMouseButton(1) && swordAnimator.GetBool("is_blocking") != true)
		{
			swordAnimator.SetTrigger("block_trigger");
		}
		if (!Input.GetMouseButton(1) && swordAnimator.GetBool("is_blocking") == true)
		{
			swordAnimator.SetBool("is_blocking", false);
		}
		/*
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.None;
			Debug.Log(("LM held"));
			//grabs mouse position relative to the camera viewport (x=0.0-1.0, y=0.0-1.0) 
			//bottom left == (0.0f,0.0f)
			mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			ScreenRegion(mousePos);	
		}

		if (!Input.GetMouseButton(0))
		{
			setFalse();
			//swordAnimator.SetTrigger("setIdle");
		}
		*/
			
	}
	void ScreenRegion(Vector3 mP)
	{
		Debug.Log("entered ScreenRegion");
		if ((mP.x > 0.33 && mP.x < 0.67) && (mP.y > 0.33 && mP.y < 0.67)) //Middle Middle
		{
			region[4] = true;
			//startT = Time.time;
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if (mP.x < 0.34 && mP.y < 0.34) //Bottom Left
		{

			if (region[4] == true)
			{
				region[0] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 0 " + region[0].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if ((mP.x > 0.33 && mP.x < 0.67) && mP.y < 0.34) //Bottom Middle
		{
			if (region[4] == true)
			{
				region[1] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 1 " + region[1].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if (mP.x > 0.66 && mP.y < 0.34) //Bottom Right
		{
			if (region[4] == true)
			{
				region[2] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 2 " + region[2].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if (mP.x < 0.34 && (mP.y > 0.33 && mP.y < 0.67)) //Middle Left
		{
			{
			if (region[4] == true)
				region[3] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 3 " + region[3].ToString());
			Debug.Log("***********************************************");
			*/
		}
		
		if (mP.x > 0.66 && (mP.y > 0.33 && mP.y < 0.67)) //Middle Right
		{
			if (region[4] == true)
			{
				region[5] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 5 " + region[5].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if (mP.x < 0.34 && mP.y > 0.66) //Top Left
		{
			if (region[4] == true)
			{
				region[6] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 6 " + region[6].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if ((mP.x > 0.33 && mP.x < 0.67) && mP.y > 0.66) //Top Middle
		{
			if (region[4] == true)
			{
				region[7] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 7 " + region[7].ToString());
			Debug.Log("***********************************************");
			*/
		}
		if (mP.x > 0.66 && mP.y > 0.66) //Top Right
		{
			if (region[4] == true)
			{
				region[8] = true;
			}
			/*
			Debug.Log("***********************************************");
			Debug.Log("region 4 " + region[4].ToString());
			Debug.Log("region 8 " + region[8].ToString());
			Debug.Log("***********************************************");
			*/
		}

        if (region[3] == true && region[5] == true)
        {
            setFalse();
            Debug.Log("swipe right to left");
            swordAnimator.SetTrigger("RTL");
            swordAnimator.SetTrigger("setIdle");
            staminaSlider.value -= 5;
            can_damage = 150;
        }
	}

	void setFalse()
	{
		for (var i = 0; i < 8; i++)
		{
			region[i] = false;
		}
	}
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy" && can_damage>0)
        {
            col.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            
        }
    }

	
	private void Event_CanAttackAgain()
	{
		// This was my test case, you can add anything you need to do after the animation has finished here
		// Like load a new scene etc
		canAttack = true;
	}

	private void Event_Attacking()
	{
		canAttack = false;
	}

	private void is_blocking()
	{
		swordAnimator.SetBool("is_blocking", true);
	}

}
