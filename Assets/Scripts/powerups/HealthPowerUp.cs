using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>().currentHeards < 3)
            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthScript>().addHeard();

        Destroy(gameObject);
    }
}
