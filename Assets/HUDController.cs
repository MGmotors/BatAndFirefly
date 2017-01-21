using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour {

	private GameObject pers;
	// Use this for initialization
	void Start () {
		pers = GameObject.Find ("PersistentGO");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnMainMenu_clicked(){
		pers.GetComponent<MusicControlScript> ().onMenuLevelLoad ();
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
}
