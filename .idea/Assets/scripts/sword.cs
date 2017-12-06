using System;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class sword : MonoBehaviour
{

	private bool[] region = new bool[9];
	public Slider staminaSlider;
	private Vector2 currAxis;
	private Vector3 mousePos;
	public int damageToGive;
	public Animator swordAnimator;
	public static int can_damage;


	// Use this for initialization
	void Start()
	{
		swordAnimator = GetComponent<Animator>();
	}




	// Update is called once per frame
	void Update()
	{
		can_damage--;

		attack();
		block();
	}

	public float highAxis = 2.0f;
	public float lowAxis = -2.0f;
	private void attack()
	{
		//if the left mouse button is held
		if (Input.GetMouseButton(0))
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = false;

			currAxis.x = Input.GetAxis("Mouse X");
			currAxis.y = Input.GetAxis("Mouse Y");

			//triggers right-ready and right_idle
			if (currAxis.x > highAxis && currAxis.y < highAxis && currAxis.y > lowAxis && swordAnimator.GetBool("readying_attack") == false)
			{
				swordAnimator.SetFloat("x-axis", currAxis.x);
				ready_attack();
				Debug.Log("right_ready");
				right_idle_on();
			}
			//triggers rlSwing
			if (currAxis.x < lowAxis && swordAnimator.GetBool("right_idle") != false)
			{
				swordAnimator.SetTrigger("RLSwing");
			}
			
			//triggers left-ready and then left_idle
			if (currAxis.x < lowAxis && currAxis.y < highAxis && currAxis.y > lowAxis && swordAnimator.GetBool("readying_attack") == false)
			{
				swordAnimator.SetFloat("x-axis", currAxis.x);
				ready_attack();
				Debug.Log("left_ready");
				left_idle_on();
			}
			//triggers lrSwing
			if (currAxis.x > highAxis && swordAnimator.GetBool("left_idle") != false)
			{
				swordAnimator.SetTrigger("LRSwing");
			}
			
			//triggers overhead ready then overhead idle
			if (currAxis.y > highAxis && currAxis.x < highAxis && currAxis.x > lowAxis && swordAnimator.GetBool("readying_attack") == false)
			{
				swordAnimator.SetFloat("y-axis", currAxis.y);
				ready_attack();
				Debug.Log("overhead_ready");
				overhead_idle_on();
			}
			if (currAxis.y < lowAxis && swordAnimator.GetBool("overhead_idle") != false)
			{
				swordAnimator.SetTrigger("overhead_swing");
			}
			
			//triggers middle_stab and then middle_stab_idle
			if (currAxis.y < lowAxis && currAxis.x < highAxis && currAxis.x > lowAxis && swordAnimator.GetBool("readying_attack") == false)
			{
				swordAnimator.SetFloat("y-axis", currAxis.y);
				ready_attack();
				Debug.Log("stab_ready");
				stab_idle_on();
			}
			//triggers middle_stab_thrust
			if (currAxis.y > highAxis && swordAnimator.GetBool("stab_idle") != false)
			{
				swordAnimator.SetTrigger("stab");
			}
		}
		
		//makes sure everything is reset when the mouse button is released
		if (!Input.GetMouseButton(0) && swordAnimator.GetBool("right_idle") == true)
		{
			unready_attack();
			right_idle_off();
			set_axis_zero();
		}
		if (!Input.GetMouseButton(0) && swordAnimator.GetBool("left_idle") == true)
		{
			unready_attack();
			left_idle_off();
			set_axis_zero();
		}
		if (!Input.GetMouseButton(0) && swordAnimator.GetBool("left_idle") == true)
		{
			unready_attack();
			left_idle_off();
			set_axis_zero();
		}
		if (!Input.GetMouseButton(0) && swordAnimator.GetBool("overhead_idle") == true)
		{
			unready_attack();
			overhead_idle_off();
			set_axis_zero();
		}
		if (!Input.GetMouseButton(0) && swordAnimator.GetBool("stab_idle") == true)
		{
			unready_attack();
			stab_idle_off();
			set_axis_zero();
		}
	}

	private void block()
	{
		//if the right mouse button is held 
		if (Input.GetMouseButton(1) && swordAnimator.GetBool("is_blocking") != true)
		{
			swordAnimator.SetTrigger("block_trigger");
		}
		//when the right mouse button is released 
		if (!Input.GetMouseButton(1) && swordAnimator.GetBool("is_blocking") == true)
		{
			is_not_blocking();
		}
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

	private void is_blocking()
	{
		swordAnimator.SetBool("is_blocking", true);
	}
	private void is_not_blocking()
	{
		swordAnimator.SetBool("is_blocking", false);
	}

	private void ready_attack()
	{
		swordAnimator.SetBool("readying_attack", true);
	}
	private void unready_attack()
	{
		swordAnimator.SetBool("readying_attack", false);
	}

	private void right_idle_on()
	{
		swordAnimator.SetBool("right_idle", true);
	}
	private void right_idle_off()
	{
		swordAnimator.SetBool("right_idle", false);
	}
	
	private void left_idle_on()
	{
		swordAnimator.SetBool("left_idle", true);
	}
	private void left_idle_off()
	{
		swordAnimator.SetBool("left_idle", false);
	}

	private void overhead_idle_on()
	{
		swordAnimator.SetBool("overhead_idle", true);
	}
	private void overhead_idle_off()
	{
		swordAnimator.SetBool("overhead_idle", false);
	}
	
	private void stab_idle_on()
	{
		swordAnimator.SetBool("stab_idle", true);
	}
	private void stab_idle_off()
	{
		swordAnimator.SetBool("stab_idle", false);
	}

	private void set_axis_zero()
	{
		swordAnimator.SetFloat("x-axis", 0.0f);
		swordAnimator.SetFloat("y-axis", 0.0f);
	}
    public void candamage()
    {
        can_damage = 60;
    }
}
