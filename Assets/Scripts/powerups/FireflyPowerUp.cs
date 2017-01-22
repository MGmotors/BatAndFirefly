using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyPowerUp : MonoBehaviour {
    public GameObject highlight;
	// Use this for initialization
	void Start () {
	    	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("highlight");
        foreach(GameObject obj in go)
        {
            obj.transform.localScale = new Vector3(obj.transform.localScale.x + 1f, obj.transform.localScale.y + 1f);
        }
        Destroy(gameObject);
    }
}
