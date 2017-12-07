using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private firstPersonController playerController;
    public GameObject pickupEffect;
    void Start()
    {
        playerController = GetComponent<firstPersonController>();

    }
    private void Update()
    {
        
    }
    void OnTriggerEnter (Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Pickup();
        }

    }

    void Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
