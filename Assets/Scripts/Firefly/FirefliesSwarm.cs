using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesSwarm : MonoBehaviour {
    public GameObject firefly;
    public int fireflyCount;
    public float radius;
    public float mvSpeed;
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
    void Update() {
        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mvTarget = new Vector2(mousePoint.x, mousePoint.y);
        Vector2 currentPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Vector2 dist = mvTarget - currentPos;
        if (dist.magnitude > 1.0f * mvSpeed * Time.deltaTime) {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + dist.normalized.x * mvSpeed * Time.deltaTime, this.gameObject.transform.position.y + dist.normalized.y * mvSpeed * Time.deltaTime, this.gameObject.transform.position.z);
        }
        else{
            this.gameObject.transform.position = new Vector3(mvTarget.x, mvTarget.y, this.gameObject.transform.position.z);
        }


    }
}
