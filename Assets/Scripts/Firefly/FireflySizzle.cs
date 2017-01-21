using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySizzle : MonoBehaviour {
    public GameObject firefly;
    public readonly int fireflyCount;
    public float radius;
    //private fireflyCountActual

	// Use this for initialization
	void Start () {
		for(int i = 0; i < fireflyCount; ++i)
        {
            Instantiate(firefly, new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius)), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
