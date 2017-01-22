using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPowerUp : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
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
			Destroy (gameObject);
		}
	}
}
