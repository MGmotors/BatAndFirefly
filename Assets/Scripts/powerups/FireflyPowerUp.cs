using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPowerUp : MonoBehaviour
{
	private PersistentScript pers;
	// Use this for initialization
	void Start ()
	{
		pers = GameObject.Find ("PersistentGO").GetComponent<PersistentScript>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (PickupSettings.maxFireflyPickups > PickupSettings.pickedUpFirefly) {
			PickupSettings.pickedUpFirefly++;
			GameObject[] go = GameObject.FindGameObjectsWithTag ("highlight");
			foreach (GameObject obj in go) {
				obj.transform.localScale = new Vector3 (obj.transform.localScale.x + PickupSettings.modifierPerFirefly, obj.transform.localScale.y + PickupSettings.modifierPerFirefly);
			}
			AudioSource c = this.gameObject.GetComponent<AudioSource> ();
			c.volume = pers.volume;
			c.Play ();
			gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			//Destroy (gameObject);
		}
	}
}
