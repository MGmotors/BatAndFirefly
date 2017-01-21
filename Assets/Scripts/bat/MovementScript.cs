using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
	public float speed;

	private float maxX;
	private float maxY;

	private BoxCollider2D myCollider;
	private float colliderHalfWidth;
	private float colliderHalfHeight;

	// Use this for initialization
	void Start () {
		// Get the main Camera
		Camera cam  = Camera.main;
		// Calculate width and height
		float height = 2f * cam.orthographicSize;
		float cameraHalfWidth = height * cam.aspect;
		// Get the max world position
		maxX = Mathf.Abs(cam.ScreenToWorldPoint (new Vector3 (cameraHalfWidth, 0)).x);
		maxY = Mathf.Abs (cam.ScreenToWorldPoint (new Vector3 (0, height)).y);


		// Get a reference to our collider
		myCollider = this.GetComponent<BoxCollider2D> ();
		colliderHalfWidth = (myCollider.size.x * this.transform.lossyScale.x / 2);
		colliderHalfHeight = (myCollider.size.y  * this.transform.lossyScale.y / 2);

		Debug.Log (maxX);
	}
	
	// Update is called once per frame
	void Update () {

		// Calculate the change in position
		Vector3 posChange = new Vector3 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, 0, 0);
		// calculate and set the result position
		Vector3 result = this.transform.position + posChange;

		//check if the new position is still on the sceen
		if (result.x - colliderHalfWidth < -maxX) {
			result.x = -maxX + colliderHalfWidth;
		}
		if (result.x + colliderHalfWidth > maxX) {
			result.x = maxX - colliderHalfWidth;
		}
		this.transform.position = result;

	

		posChange = new Vector3 (0, Input.GetAxis ("Vertical") * speed * Time.deltaTime);
		result = transform.position + posChange;
		if ((result.y + colliderHalfHeight) > maxY) {
			result.y = maxY - colliderHalfHeight;
		}

		if ((result.y - colliderHalfHeight) < -maxY) {
			result.y = -maxY + colliderHalfHeight;
		}

		this.transform.position = result;

	}


}
