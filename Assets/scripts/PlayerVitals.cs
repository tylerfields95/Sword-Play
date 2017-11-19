using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.Characters.FirstPerson;

public class PlayerVitals : MonoBehaviour {

    public Slider healthSlider;
    public int maxHealth;
    int damage = 10;
    public Slider staminaSlider;
    public int maxStamina;
    private int staminaFallRate;
    public int staminaFallMult;
    private int staminaRegainRate;
    public int staminaRegainMult;

    private CharacterController charController;
    private firstPersonController playerController;

    void Start()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;

        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;

        staminaFallRate = 1;
        staminaRegainRate = 1;

        charController = GetComponent<CharacterController>();
        Debug.Log(charController.velocity.magnitude);
        playerController = GetComponent<firstPersonController>();
    }

   // private void OnCollisionEnter(Collider other)
   // {
       // if (other.gameObject.tag == "Enemy")
      //  {
           // healthSlider.value -= damage;
          //  print("TESTTESTTEST");
        //}
   // }
    void Update()
    {
        //Health control section

        //Stamina control section
        if (charController.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            staminaSlider.value -= Time.deltaTime / staminaFallRate * staminaFallMult;
        }

        else
        {
            staminaSlider.value += Time.deltaTime / staminaRegainRate * staminaRegainMult;
        }

        if (staminaSlider.value >= maxStamina)
        {
            staminaSlider.value = maxStamina;
        }
        else if (staminaSlider.value <= 0)
        {
            staminaSlider.value = 0;
            playerController.movementSpeed = playerController.walkSpeed;
        }

        else if(staminaSlider.value >= 0)
        {
            playerController.movementSpeed = playerController.movementSpeedNorm;
        }
    }
}
