using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarScript : MonoBehaviour {
    public GameObject wave;
    public float timeBetweenWaves;
    public float timePassedSinceLastWave;

	// Use this for initialization
	void Start () {
        timePassedSinceLastWave = 0.0f;
        // Create a wave
        Instantiate(wave, this.transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        timePassedSinceLastWave += Time.deltaTime;
        if(timePassedSinceLastWave >= timeBetweenWaves)
        {
            // Create a wave
            Instantiate(wave, this.transform.position, Quaternion.identity);
            timePassedSinceLastWave -= timeBetweenWaves;
        }
	}
}
