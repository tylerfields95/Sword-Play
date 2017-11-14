using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit : MonoBehaviour {

    public Slider healthSlider;
    public int maxHealth;
    private int damage = 10;
    
    // Use this for initialization
    //void Start () {
        //healthSlider.maxValue = maxHealth;
        //healthSlider.value = maxHealth;
   // }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            healthSlider.value -= damage;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
