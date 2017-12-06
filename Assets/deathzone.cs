using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour {

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
