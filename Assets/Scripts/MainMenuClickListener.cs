using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuClickListener : MonoBehaviour {
	public Slider sldrVolume;
	public Slider sldrBrightness;
	public Text txtScore;

	private GameObject pers;
	// Use this for initialization
	void Start () {
		pers = GameObject.Find ("PersistentGO");
		sldrVolume.onValueChanged.AddListener (delegate {
			sldrVolume_Changed();
		});

		sldrVolume.value = pers.GetComponent<PersistentScript> ().volume;

		txtScore.text = HighscoreManager.GetHighscore ().ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnQuit_clicked(){
		Application.Quit ();
	}

	public void btnStart_clicked(){
		SceneManager.LoadScene ("TestLevel", LoadSceneMode.Single);
		if (pers != null) {
			pers.GetComponent<MusicControlScript> ().onMainLevelLoad ();
		} else {
			Debug.Log ("null bei level load!");
		}
	}

	public void sldrVolume_Changed(){
		pers.GetComponent<PersistentScript> ().volume = sldrVolume.value;
	}

	public void btnTutorial_clicked(){
		SceneManager.LoadScene ("TutorialScene", LoadSceneMode.Single);
		if (pers != null) {
			pers.GetComponent<MusicControlScript> ().onMainLevelLoad ();
		} else {
			Debug.Log ("null bei level load!");
		}
	}
}
