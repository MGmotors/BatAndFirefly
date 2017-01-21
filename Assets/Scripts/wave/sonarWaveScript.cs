using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonarWaveScript : MonoBehaviour {

    public float disappearTime;
    public float moveForwardTime;
    public float scaleTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpriteRenderer sr = this.GetComponent<SpriteRenderer>();
        // fade
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - disappearTime * Time.deltaTime);
        if(sr.color.a <= 0.0f)
        {
            Destroy(this);
        }
        transform.localScale += scaleTime * new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y + moveForwardTime * Time.deltaTime, transform.position.z);
	}
}
