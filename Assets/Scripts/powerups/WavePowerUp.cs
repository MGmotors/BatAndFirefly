using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePowerUp : MonoBehaviour {

	private PersistentScript pers;
	// Use this for initialization
	void Start () {
		pers = GameObject.Find ("PersistentGO").GetComponent<PersistentScript>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
		if (PickupSettings.maxSonarPickups > PickupSettings.pickedUpSonars) {
			PickupSettings.pickedUpSonars++;
			GameObject.FindGameObjectWithTag("Player").GetComponent<SonarScript>().timeBetweenWaves *= PickupSettings.modifierPerSonar;
			AudioSource c = this.gameObject.GetComponent<AudioSource> ();
			c.volume = pers.volume;
			c.Play ();
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			//Destroy(gameObject);
		}

    }
}
