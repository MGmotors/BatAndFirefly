using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickupSpawnScript : MonoBehaviour {

	public GameObject scorePrefab;
	public int numScorePickups;
	// Use this for initialization
	void Start () {
		float halfX = this.GetComponent<SpriteRenderer> ().bounds.size.x / 2;
		float maxY = this.GetComponent<SpriteRenderer> ().bounds.size.y;
		GameObject o;
		Vector3 parentPos;
		for (int i = 0; i < numScorePickups; i++) {
			parentPos = this.gameObject.transform.transform.position;
			o = GameObject.Instantiate (scorePrefab);
			o.transform.position = new Vector3 (parentPos.x + Random.Range (-halfX, halfX),parentPos.y + Random.Range (-maxY/2, maxY/2),0);
			o.transform.parent = this.gameObject.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
