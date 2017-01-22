using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

	public float score;
	private PersistentScript pers;

	// Use this for initialization
	void Start () {
		pers = GameObject.Find ("PersistentGO").GetComponent<PersistentScript>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other) {
		GameObject o = other.gameObject;
		// Did we hit the player
		if (o.CompareTag ("Player")) {
			ScoreScript scs = o.GetComponent<ScoreScript> ();
			scs.addScore (score, true);
			scs.miceEaten++;
			//o.GetComponent<HealthScript> ().removeHeard ();
			AudioSource c = this.gameObject.GetComponent<AudioSource> ();
			c.volume = pers.volume;
			c.Play ();
		} else {
			//Destroy (this.gameObject);
		}
		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		//
	}
		
}
