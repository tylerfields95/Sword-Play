using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class deathzone : MonoBehaviour {

    public Slider healthSlider;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
        healthSlider.value = 100;
    }
}
