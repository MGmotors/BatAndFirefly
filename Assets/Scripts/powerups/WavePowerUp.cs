using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePowerUp : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (PickupSettings.maxSonarPickups > PickupSettings.pickedUpSonars) {
			PickupSettings.pickedUpSonars++;
			GameObject.FindGameObjectWithTag("Player").GetComponent<SonarScript>().timeBetweenWaves *= PickupSettings.modifierPerSonar;
			Destroy(gameObject);
		}

    }
}
