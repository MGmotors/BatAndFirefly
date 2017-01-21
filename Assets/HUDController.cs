using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void btnMainMenu_clicked(){
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
}
