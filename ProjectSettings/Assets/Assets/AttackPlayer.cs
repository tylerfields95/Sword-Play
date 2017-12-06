using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AttackPlayer : MonoBehaviour {

    private Transform player;
	void Start () {
        player = GameObject.Find("Test sword").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player);
        transform.position = Vector3.MoveTowards(transform.position, player.position, 2 * Time.deltaTime);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().name == "Test sword")
        {
            Application.LoadLevel(0);
        }
    }
}
