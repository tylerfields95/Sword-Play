using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class HealthUpgrade : MonoBehaviour
{

    private firstPersonController playerController;
    public GameObject pickupEffect;
    public int upgradeHealth;
    public Slider healthSlider;
    void Start()
    {
        playerController = GetComponent<firstPersonController>();

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Pickup();
            healthSlider.maxValue = upgradeHealth;
            healthSlider.value = upgradeHealth;
        }

    }

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }
}
