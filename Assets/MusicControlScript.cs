using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript : MonoBehaviour {
	public AudioSource menuMusic;
	public AudioSource gameMusic;
	public float fadeSpeed;

	private AudioSource oldA;
	private AudioSource newA;

	private float fadeLevel;

	private PersistentScript settings;

	// Use this for initialization
	void Start () {
		GameObject s = GameObject.Find ("PersistentGO");
		if (s != null) {
			settings = s.GetComponent<PersistentScript> ();
		} 

		if (settings == null) {
			Debug.Log ("Settings ist null!");
		}
		fadeLevel = 1;

		newA = menuMusic;
	}
	
	// Update is called once per frame
	void Update () {
		if (settings.Equals (null)) {
			return;
		}
		if (fadeLevel < 1) {
			fadeLevel += Time.deltaTime * fadeSpeed;
			oldA.volume = settings.volume - settings.volume * fadeLevel;
			newA.volume = settings.volume * fadeLevel;
		} else {
			newA.volume = settings.volume;
		}
	}

	public void onMainLevelLoad(){
		Debug.Log ("on main level load");
		oldA = menuMusic;
		newA = gameMusic;
		fadeLevel = 0;
	}

	public void onMenuLevelLoad(){
		newA = menuMusic;
		oldA = gameMusic;
		fadeLevel = 0;
	}
}
