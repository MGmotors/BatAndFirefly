using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesSwarm : MonoBehaviour {
    public GameObject firefly;
    public int fireflyCount;
    public float radius;
    //private fireflyCountActual

	// Use this for initialization
	void Start () {
		for(int i = 0; i < fireflyCount-1; ++i)
        {
            GameObject go = Instantiate(firefly, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            go.transform.SetParent(this.gameObject.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
		//
	}
}
