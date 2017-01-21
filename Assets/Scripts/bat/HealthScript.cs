using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
	// The hard to Be used
	public GameObject heartPrefab;
	// The panel used as parent for the Hearts
	public GameObject uiPanel;
	public Text gameOverText;
	// Health to start with
	public int startingHeards;

	public AudioClip acHeardUp;
	public AudioClip acHeardDown;

	private int currentHeards;
	private List<GameObject> heartsOnScreen;

	private Animator anim;
	private SpriteRenderer sRenderer;

	// Stuff for blinking
	private int timesToBlinkLeft;
	private float timeSinceLastBlink;
	private const float BLINKING_SPEED = 0.2f;

	private AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
		currentHeards = startingHeards;
		heartsOnScreen = new List<GameObject>();
		for (int i = 0; i < currentHeards; i++) {
			GameObject o = GameObject.Instantiate (heartPrefab);
			o.transform.SetParent (uiPanel.transform);
			heartsOnScreen.Add (o);
		}

		sRenderer = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		myAudioSource = this.gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timesToBlinkLeft > 0) {
			timeSinceLastBlink += Time.deltaTime;
			if (timeSinceLastBlink > BLINKING_SPEED) {
				if (anim.enabled) {
					anim.enabled = false;
					sRenderer.enabled = false;
				} else {
					anim.enabled = true;
					sRenderer.enabled = true;
				}

				timeSinceLastBlink = 0;
				timesToBlinkLeft --;
			}
		}
	}

	public void removeHeard(){
		// Dont remove hard while blinking
		if (timesToBlinkLeft > 0)
			return;
		
		if (currentHeards > 0) {
			
			currentHeards--;
			GameObject o = heartsOnScreen [0];
			GameObject.Destroy (o);
			heartsOnScreen.RemoveAt (0);
			timeSinceLastBlink = BLINKING_SPEED;
			timesToBlinkLeft = 3 * 2;

			//play sound
			myAudioSource.clip = acHeardDown;
			myAudioSource.Play ();
		}

		if (currentHeards <= 0) {
			this.gameObject.SetActive (false);
			gameOverText.text = "GAME OVER";
		}
	
	}


	public void addHeard(){
		this.currentHeards++;
		GameObject o = GameObject.Instantiate (heartPrefab);
		o.transform.SetParent (uiPanel.transform);
		heartsOnScreen.Add (o);

		//play sound
		myAudioSource.clip = acHeardUp;
		myAudioSource.Play ();
	}
}
