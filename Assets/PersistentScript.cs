using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentScript : MonoBehaviour {

	public float volume;
	public float brightness;

	// Use this for initialization
	void Start () {
		Object.DontDestroyOnLoad (this.gameObject);
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
