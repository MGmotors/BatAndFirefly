using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zOrder : MonoBehaviour {
    public SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        sr.sortingOrder = 1000 - (int)transform.position.y * 10;
	}
}
