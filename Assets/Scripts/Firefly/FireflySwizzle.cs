using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflySwizzle : MonoBehaviour {
    public Vector2 mvTarget;
    private float radius;
    private Vector2 prevTarget;
    private Vector2 distance;

    // Use this for initialization
    void Start () {
        prevTarget = new Vector2(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y);
        // Set random target
        radius = this.transform.parent.GetComponent<FirefliesSwarm>().radius;
        mvTarget = new Vector2(Random.Range(-radius, radius), Random.Range(-radius, radius));
        distance = mvTarget - prevTarget;
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.localPosition += Time.deltaTime * new Vector3(distance.normalized.x, distance.normalized.y, 0.0f);
        if((new Vector2(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y) - prevTarget).magnitude >= distance.magnitude)
        {
            // Set new random target
            prevTarget = mvTarget;
            mvTarget = new Vector2(Random.Range(-radius, radius), Random.Range(-radius, radius));
            distance = mvTarget - prevTarget;
        }
	}
}
