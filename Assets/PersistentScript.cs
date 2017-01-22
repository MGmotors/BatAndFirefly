using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentScript : MonoBehaviour {

	public float volume;
	public float brightness;

	public float splashScreenDelay;
	private float splashScreenOpen;
	private bool splashScreenFinished;

	// Use this for initialization
	void Start () {
		splashScreenOpen = 0;
		splashScreenFinished = false;
		Object.DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (!splashScreenFinished) {
			splashScreenOpen += Time.deltaTime;
			if (splashScreenOpen > splashScreenDelay) {
				splashScreenFinished = true;
				SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
			}
		}
	}
}
