using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectHit : MonoBehaviour {
	private Animator anim;

	public bool parry;
    public Slider healthSlider;
    public int maxHealth;
    public int damage;
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    
    // Use this for initialization
    //void Start () {
        //healthSlider.maxValue = maxHealth;
        //healthSlider.value = maxHealth;
   // }
    private void OnTriggerEnter(Collider col)
    {
    	if(col.name=="HumanSword"){
			Debug.Log("PARRY/BLOCK");
			parry = true;
			GetBack();
			anim.SetTrigger("is_blocked");
		

			
		
		
		}
        if (col.tag == "Hitbox")
        {
            healthSlider.value -= damage;
            Debug.Log("hit player");
        }
    }

    // Update is called once per frame
    void Update () {
    	if(healthSlider.value <=0){
    		player.transform.position = respawnPoint.transform.position;
    		healthSlider.value = 100;
    	}
		
	}
    void Start () {
		anim = transform.root.GetComponent<Animator>();
		
	}
    	void  GetBack(){
		CharacterController controller = transform.root.GetComponent<CharacterController>();
		Vector3 direction = player.position - transform.root.transform.position;
		Debug.Log(direction);
		direction.y=0;
		direction = direction*-2.0f;
				Debug.Log("2: "+direction);
		controller.Move(direction * 10*Time.deltaTime);
					Debug.Log("they should have moved");			

	
		
	}
}
