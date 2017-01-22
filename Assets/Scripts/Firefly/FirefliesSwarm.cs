using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesSwarm : MonoBehaviour {
    public GameObject firefly;
    public int fireflyCount;
    public float radius;
    public float mvSpeed;
    private float useMvSpeed;
    //private fireflyCountActual

	// Use this for initialization
	void Start () {
        // Check for eyetracker
        Tobii.EyeTracking.DeviceStatus deviceStatus = Tobii.EyeTracking.EyeTrackingHost.GetInstance().EyeTrackingDeviceStatus;
        if (deviceStatus == Tobii.EyeTracking.DeviceStatus.Pending)
        {
            Tobii.EyeTracking.EyeTracking.Initialize();
        }
        else if (deviceStatus == Tobii.EyeTracking.DeviceStatus.Tracking)
        {

        }
		for(int i = 0; i < fireflyCount-1; ++i)
        {
            GameObject go = Instantiate(firefly, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            go.transform.SetParent(this.gameObject.transform);
        }
        useMvSpeed = mvSpeed;
	}

    // Update is called once per frame
    void Update() {
        Vector3 mousePoint;
        //Tobii.EyeTracking.DeviceStatus deviceStatus = Tobii.EyeTracking.EyeTrackingHost.GetInstance().EyeTrackingDeviceStatus;
        //Debug.Log(deviceStatus);
        Tobii.EyeTracking.GazePoint gp = Tobii.EyeTracking.EyeTracking.GetGazePoint();

        mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gp.IsValid && gp.IsWithinScreenBounds)
        {
            mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(gp.Screen.x, gp.Screen.y, 0.0f));
            // Move faster when eyetracker is used
            useMvSpeed = mvSpeed + 10.0f;
        }
        else
        {
            useMvSpeed = mvSpeed;
        }
        Vector2 mvTarget = new Vector2(mousePoint.x, mousePoint.y);
        Vector2 currentPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Vector2 dist = mvTarget - currentPos;
        if (dist.magnitude > 1.0f * useMvSpeed * Time.deltaTime) {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + dist.normalized.x * useMvSpeed * Time.deltaTime, this.gameObject.transform.position.y + dist.normalized.y * mvSpeed * Time.deltaTime, this.gameObject.transform.position.z);
        }
        else{
            this.gameObject.transform.position = new Vector3(mvTarget.x, mvTarget.y, this.gameObject.transform.position.z);
        }


    }
}
